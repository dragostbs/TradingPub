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
        [DisplayName("Transaction ID")]
        public int TransactionID { get; set; }
        [DisplayName("Trader ID")]
        public int TraderID { get; set; }
        [DisplayName("Quotation ID")]
        public int QuotationID { get; set; }
        public Trader Trader { get; set; }
        public Quotation Quotation { get; set; }
    }
}
