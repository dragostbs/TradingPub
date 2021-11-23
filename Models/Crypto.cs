using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    // Crypto Quotations
    public class Crypto
    {
        [DisplayName("Crypto ID")]
        public int ID { get; set; }
        [DisplayName("Crypto Name")]
        public string Name { get; set; }
        [DisplayName("Trading Price")]
        public decimal Price { get; set; }
    }
}
