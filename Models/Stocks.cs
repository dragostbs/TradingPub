using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    // Stocks Quotations
    public class Stocks
    {
        [DisplayName("Stock ID")]
        public int ID { get; set; }
        [DisplayName("Stock Name")]
        public string Name { get; set; }
        [DisplayName("Trading Price")]
        public decimal Price { get; set; }
    }
}
