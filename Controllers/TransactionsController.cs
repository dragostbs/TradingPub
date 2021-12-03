using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TradingPub.Data;
using TradingPub.Models;

namespace TradingPub.Models
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationContext _context;

        public TransactionsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["TraderSortParm"] = sortOrder == "Trader" ? "trader_desc" : "Trader";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["ResultSortParm"] = sortOrder == "Result" ? "result_desc" : "Result";
            ViewData["AmountSortParm"] = sortOrder == "Amount" ? "amount_desc" : "Amount";
            var transactions = from b in _context.Transactions.Include(b => b.Quotation).Include(b => b.Trader)
                                select b;
            switch (sortOrder)
            {
                case "name_desc":
                    transactions = transactions.OrderByDescending(b => b.Quotation);
                    break;
                case "Amount":
                    transactions = transactions.OrderBy(b => b.ForexAmount);
                    break;
                case "amount_desc":
                    transactions = transactions.OrderByDescending(b => b.ForexAmount);                   
                    break;
                case "Result":
                    transactions = transactions.OrderBy(b => b.ForexResult);
                    break;
                case "result_desc":
                    transactions = transactions.OrderByDescending(b => b.ForexResult);
                    break;
                case "Trader":
                    transactions = transactions.OrderBy(b => b.Trader);
                    break;
                case "trader_desc":
                    transactions = transactions.OrderByDescending(b => b.Trader);
                    break;
                case "Price":
                    transactions = transactions.OrderBy(b => b.Quotation.Price);
                    break;
                case "price_desc":
                    transactions = transactions.OrderByDescending(b => b.Quotation.Price);
                    break;
                default:
                    transactions = transactions.OrderBy(b => b.Quotation);
                    break;
            }
            return View(await transactions.AsNoTracking().ToListAsync());
        }
    }
}
