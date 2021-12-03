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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["StockSortParm"] = String.IsNullOrEmpty(sortOrder) ? "stock_desc" : "";
            ViewData["TraderSortParm"] = sortOrder == "Trader" ? "trader_desc" : "Trader";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["ResultSortParm"] = sortOrder == "Result" ? "result_desc" : "Result";
            ViewData["AmountSortParm"] = sortOrder == "Amount" ? "amount_desc" : "Amount";
            ViewData["CurrentFilter"] = searchString;
            var transactions = from b in _context.StocksTransactions.Include(b => b.Stocks).Include(b => b.Trader)
                               select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                transactions = transactions.Where(s => s.Trader.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "stock_desc":
                    transactions = transactions.OrderByDescending(b => b.Stocks);
                    break;
                case "Amount":
                    transactions = transactions.OrderBy(b => b.StockAmount);
                    break;
                case "amount_desc":
                    transactions = transactions.OrderByDescending(b => b.StockAmount);
                    break;
                case "Result":
                    transactions = transactions.OrderBy(b => b.StockResult);
                    break;
                case "result_desc":
                    transactions = transactions.OrderByDescending(b => b.StockResult);
                    break;
                case "Trader":
                    transactions = transactions.OrderBy(b => b.Trader);
                    break;
                case "trader_desc":
                    transactions = transactions.OrderByDescending(b => b.Trader);
                    break;
                case "Price":
                    transactions = transactions.OrderBy(b => b.Stocks.Price);
                    break;
                case "price_desc":
                    transactions = transactions.OrderByDescending(b => b.Stocks.Price);
                    break;
                default:
                    transactions = transactions.OrderBy(b => b.Stocks);
                    break;
            }
            return View(await transactions.AsNoTracking().ToListAsync());
        }
    }
}