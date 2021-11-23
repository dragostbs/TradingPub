﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    // Forex Quotations
    public class Quotation
    {
        [DisplayName("Quotation ID")]
        public int ID { get; set; }
        [DisplayName("Quotation Name")]
        public string Name { get; set; }
        [DisplayName("Trading Price")]
        public decimal Price { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}