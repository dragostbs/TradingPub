using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    public class CryptoTransaction
    {
        [DisplayName("Crypto Transaction ID")]
        public int CryptoTransactionID { get; set; }
        [DisplayName("Result")]
        public string CryptoResult { get; set; }
        [DisplayName("Amount")]
        [DataType(DataType.Currency)]
        public float? CryptoAmount { get; set; }
        [DisplayName("Trader ID")]
        public int TraderID { get; set; }
        [DisplayName("Crypto Quotation ID")]
        public int CryptoID { get; set; }
        public Trader Trader { get; set; }
        public Crypto Crypto { get; set; }
    }
}
