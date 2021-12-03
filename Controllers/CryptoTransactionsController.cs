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
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["CryptoSortParm"] = String.IsNullOrEmpty(sortOrder) ? "crypto_desc" : "";
            ViewData["TraderSortParm"] = sortOrder == "Trader" ? "trader_desc" : "Trader";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["ResultSortParm"] = sortOrder == "Result" ? "result_desc" : "Result";
            ViewData["AmountSortParm"] = sortOrder == "Amount" ? "amount_desc" : "Amount";
            var transactions = from b in _context.CryptoTransactions.Include(b => b.Crypto).Include(b => b.Trader)
                               select b;
            switch (sortOrder)
            {
                case "crypto_desc":
                    transactions = transactions.OrderByDescending(b => b.Crypto);
                    break;
                case "Amount":
                    transactions = transactions.OrderBy(b => b.CryptoAmount);
                    break;
                case "amount_desc":
                    transactions = transactions.OrderByDescending(b => b.CryptoAmount);
                    break;
                case "Result":
                    transactions = transactions.OrderBy(b => b.CryptoResult);
                    break;
                case "result_desc":
                    transactions = transactions.OrderByDescending(b => b.CryptoResult);
                    break;
                case "Trader":
                    transactions = transactions.OrderBy(b => b.Trader);
                    break;
                case "trader_desc":
                    transactions = transactions.OrderByDescending(b => b.Trader);
                    break;
                case "Price":
                    transactions = transactions.OrderBy(b => b.Crypto.Price);
                    break;
                case "price_desc":
                    transactions = transactions.OrderByDescending(b => b.Crypto.Price);
                    break;
                default:
                    transactions = transactions.OrderBy(b => b.Crypto);
                    break;
            }
            return View(await transactions.AsNoTracking().ToListAsync());
        }
    }
}