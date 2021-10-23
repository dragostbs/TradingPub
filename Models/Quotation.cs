using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    // Forex ex: Eur/Usd, Futures ex: Oil
    public class Quotation
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}