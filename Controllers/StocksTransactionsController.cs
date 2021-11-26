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
    }
}