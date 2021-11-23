using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    public class StocksTransaction
    {
        [DisplayName("Stock Transaction ID")]
        public int StocksTransactionID { get; set; }
        [DisplayName("Trader ID")]
        public int TraderID { get; set; }
        [DisplayName("Stock Quotation ID")]
        public int StocksID { get; set; }
        public Trader Trader { get; set; }
        public Stocks Stocks { get; set; }
    }
}
