using Microsoft.EntityFrameworkCore;
using TradingPub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace TradingPub.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            System.Globalization.CultureInfo modCulture = new System.Globalization.CultureInfo("en-US");
            modCulture.NumberFormat.CurrencyNegativePattern = 1;
            Thread.CurrentThread.CurrentCulture = modCulture;
        }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<Trader> Traders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<CryptoTransaction> CryptoTransactions { get; set; }
        public DbSet<StocksTransaction> StocksTransactions { get; set; }
    }
}
