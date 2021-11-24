using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    public class Transaction
    {
        [DisplayName("Forex ID")]
        public int TransactionID { get; set; }
        [DisplayName("Trader ID")]
        public int TraderID { get; set; }
        [DisplayName("Forex ID")]
        public int QuotationID { get; set; }
        public Trader Trader { get; set; }
        [DisplayName("Forex")]
        public Quotation Quotation { get; set; }
    }
}
