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
    public class TradersController : Controller
    {
        private readonly ApplicationContext _context;

        public TradersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Traders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Traders.ToListAsync());
        }

        // GET: Traders/Details/5
        [Authorize(Roles = "Trader")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trader = await _context.Traders
                .FirstOrDefaultAsync(m => m.TraderID == id);
            if (trader == null)
            {
                return NotFound();
            }

            return View(trader);
        }

        // GET: Traders/Create
        [Authorize(Policy = "OnlyManagers")]
        public IActionResult Create()
        {
            Trader trd = new Trader();
            return PartialView("_TraderModelPartial", trd);
        }

        // POST: Traders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraderID,Name,Adress")] Trader trader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trader);
        }

        // GET: Traders/Edit/5
        [Authorize(Policy = "OnlyManagers")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trader = await _context.Traders.FindAsync(id);
            if (trader == null)
            {
                return NotFound();
            }
            return View(trader);
        }

        // POST: Traders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraderID,Name,Adress")] Trader trader)
        {
            if (id != trader.TraderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraderExists(trader.TraderID))
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
            return View(trader);
        }

        // GET: Traders/Delete/5
        [Authorize(Policy = "OnlyManagers")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trader = await _context.Traders
                .FirstOrDefaultAsync(m => m.TraderID == id);
            if (trader == null)
            {
                return NotFound();
            }

            return View(trader);
        }

        // POST: Traders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trader = await _context.Traders.FindAsync(id);
            _context.Traders.Remove(trader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraderExists(int id)
        {
            return _context.Traders.Any(e => e.TraderID == id);
        }
    }
}
