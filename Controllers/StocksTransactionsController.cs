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
    public class StocksTransactionsController : Controller
    {
        private readonly ApplicationContext _context;

        public StocksTransactionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: StocksTransactions
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.StocksTransactions.Include(s => s.Stocks).Include(s => s.Trader);
            return View(await applicationContext.ToListAsync());
        }

        // GET: StocksTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksTransaction = await _context.StocksTransactions
                .Include(s => s.Stocks)
                .Include(s => s.Trader)
                .FirstOrDefaultAsync(m => m.StocksTransactionID == id);
            if (stocksTransaction == null)
            {
                return NotFound();
            }

            return View(stocksTransaction);
        }

        // GET: StocksTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksTransaction = await _context.StocksTransactions.FindAsync(id);
            if (stocksTransaction == null)
            {
                return NotFound();
            }
            ViewData["StocksID"] = new SelectList(_context.Stocks, "ID", "ID", stocksTransaction.StocksID);
            ViewData["TraderID"] = new SelectList(_context.Traders, "TraderID", "TraderID", stocksTransaction.TraderID);
            return View(stocksTransaction);
        }

        // POST: StocksTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StocksTransactionID,TraderID,StocksID")] StocksTransaction stocksTransaction)
        {
            if (id != stocksTransaction.StocksTransactionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stocksTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StocksTransactionExists(stocksTransaction.StocksTransactionID))
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
            ViewData["StocksID"] = new SelectList(_context.Stocks, "ID", "ID", stocksTransaction.StocksID);
            ViewData["TraderID"] = new SelectList(_context.Traders, "TraderID", "TraderID", stocksTransaction.TraderID);
            return View(stocksTransaction);
        }

        // GET: StocksTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stocksTransaction = await _context.StocksTransactions
                .Include(s => s.Stocks)
                .Include(s => s.Trader)
                .FirstOrDefaultAsync(m => m.StocksTransactionID == id);
            if (stocksTransaction == null)
            {
                return NotFound();
            }

            return View(stocksTransaction);
        }

        // POST: StocksTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stocksTransaction = await _context.StocksTransactions.FindAsync(id);
            _context.StocksTransactions.Remove(stocksTransaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StocksTransactionExists(int id)
        {
            return _context.StocksTransactions.Any(e => e.StocksTransactionID == id);
        }
    }
}
