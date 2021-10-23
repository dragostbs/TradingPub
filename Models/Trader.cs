using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPub.Models
{
    // Trader info
    public class Trader
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TraderID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
