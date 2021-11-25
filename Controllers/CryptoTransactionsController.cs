using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradingPub.Data;
using TradingPub.Models;

namespace TradingPub.Controllers
{
    public class CryptoTransactionsController : Controller
    {
        private readonly ApplicationContext _context;

        public CryptoTransactionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: CryptoTransactions
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.CryptoTransactions.Include(c => c.Crypto).Include(c => c.Trader);
            return View(await applicationContext.ToListAsync());
        }

        // GET: CryptoTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cryptoTransaction = await _context.CryptoTransactions
                .Include(c => c.Crypto)
                .Include(c => c.Trader)
                .FirstOrDefaultAsync(m => m.CryptoTransactionID == id);
            if (cryptoTransaction == null)
            {
                return NotFound();
            }

            return View(cryptoTransaction);
        }

        // GET: CryptoTransactions/Create
        [HttpGet]
        public IActionResult Create()
        {
            CryptoTransaction cry = new CryptoTransaction();
            ViewData["CryptoID"] = new SelectList(_context.Cryptos, "ID", "ID");
            ViewData["TraderID"] = new SelectList(_context.Traders, "TraderID", "TraderID");
            return PartialView("_CryptoTransactionModelPartial", cry);
        }

        // POST: CryptoTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CryptoTransactionID,TraderID,CryptoID")] CryptoTransaction cryptoTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cryptoTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CryptoID"] = new SelectList(_context.Cryptos, "ID", "ID", cryptoTransaction.CryptoID);
            ViewData["TraderID"] = new SelectList(_context.Traders, "TraderID", "TraderID", cryptoTransaction.TraderID);
            return View(cryptoTransaction);
        }

        // GET: CryptoTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cryptoTransaction = await _context.CryptoTransactions.FindAsync(id);
            if (cryptoTransaction == null)
            {
                return NotFound();
            }
            ViewData["CryptoID"] = new SelectList(_context.Cryptos, "ID", "ID", cryptoTransaction.CryptoID);
            ViewData["TraderID"] = new SelectList(_context.Traders, "TraderID", "TraderID", cryptoTransaction.TraderID);
            return View(cryptoTransaction);
        }

        // POST: CryptoTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CryptoTransactionID,TraderID,CryptoID")] CryptoTransaction cryptoTransaction)
        {
            if (id != cryptoTransaction.CryptoTransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cryptoTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CryptoTransactionExists(cryptoTransaction.CryptoTransactionID))
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
            ViewData["CryptoID"] = new SelectList(_context.Cryptos, "ID", "ID", cryptoTransaction.CryptoID);
            ViewData["TraderID"] = new SelectList(_context.Traders, "TraderID", "TraderID", cryptoTransaction.TraderID);
            return View(cryptoTransaction);
        }

        // GET: CryptoTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cryptoTransaction = await _context.CryptoTransactions
                .Include(c => c.Crypto)
                .Include(c => c.Trader)
                .FirstOrDefaultAsync(m => m.CryptoTransactionID == id);
            if (cryptoTransaction == null)
            {
                return NotFound();
            }

            return View(cryptoTransaction);
        }

        // POST: CryptoTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cryptoTransaction = await _context.CryptoTransactions.FindAsync(id);
            _context.CryptoTransactions.Remove(cryptoTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CryptoTransactionExists(int id)
        {
            return _context.CryptoTransactions.Any(e => e.CryptoTransactionID == id);
        }
    }
}
