using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradingPub.Data;
using TradingPub.Models;

namespace TradingPub.Controllers
{
    public class CryptosController : Controller
    {
        private readonly ApplicationContext _context;

        public CryptosController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Cryptos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cryptos.ToListAsync());
        }

        // GET: Cryptos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crypto = await _context.Cryptos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (crypto == null)
            {
                return NotFound();
            }

            return View(crypto);
        }

        // GET: Cryptos/Create
        [HttpGet]
        [Authorize(Policy = "OnlyManagers")]
        public IActionResult Create()
        {
            Crypto pto = new Crypto();
            return PartialView("_CryptoModelPartial", pto);
        }

        // POST: Cryptos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price")] Crypto crypto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crypto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crypto);
        }

        // GET: Cryptos/Edit/5
        [Authorize(Policy = "OnlyManagers")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crypto = await _context.Cryptos.FindAsync(id);
            if (crypto == null)
            {
                return NotFound();
            }
            return View(crypto);
        }

        // POST: Cryptos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price")] Crypto crypto)
        {
            if (id != crypto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crypto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CryptoExists(crypto.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(crypto);
        }

        // GET: Cryptos/Delete/5
        [Authorize(Policy = "OnlyManagers")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crypto = await _context.Cryptos
                .FirstOrDefaultAsync(m => m.ID == id);
            if (crypto == null)
            {
                return NotFound();
            }

            return View(crypto);
        }

        // POST: Cryptos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var crypto = await _context.Cryptos.FindAsync(id);
            _context.Cryptos.Remove(crypto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CryptoExists(int id)
        {
            return _context.Cryptos.Any(e => e.ID == id);
        }
    }
}
