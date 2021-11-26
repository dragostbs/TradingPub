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
    }
}