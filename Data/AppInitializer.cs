using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPub.Models;

namespace TradingPub.Data
{
    public class AppInitializer
    {
        public static void Initialize(ApplicationContext context)
        {
            // Connect to DB
            context.Database.EnsureCreated();
            if (context.Quotations.Any())
            {
                return;
            }

            // Quotations 
            var quotations = new Quotation[]
            {
                new Quotation{Name="EUR/USD",Price=Decimal.Parse("1.16")},
                new Quotation{Name="USD/JPY",Price=Decimal.Parse("113.46")},
                new Quotation{Name="GPY/USD",Price=Decimal.Parse("1.37")},
                new Quotation{Name="AUD/USD",Price=Decimal.Parse("0.74")},
                new Quotation{Name="USD/CAD",Price=Decimal.Parse("1.23")},
                new Quotation{Name="USD/CHF",Price=Decimal.Parse("0.91")},
                new Quotation{Name="NZD/USD",Price=Decimal.Parse("0.71")}
            };
            foreach (Quotation s in quotations)
            {
                context.Quotations.Add(s);
            }
            context.SaveChanges();

            // Traders
            var traders = new Trader[]
            {
                new Trader { TraderID = 00232, Name = "John Cyrus", Adress = "Stones street 45" },
                new Trader { TraderID = 00426, Name = "Nina Crown", Adress = "Horizon street 97" },
                new Trader { TraderID = 00537, Name = "Steve Aoki", Adress = "London street 22" },
                new Trader { TraderID = 00956, Name = "Spencer Krasinski", Adress = "Noborev street 19" },
                new Trader { TraderID = 00774, Name = "Anne Albright", Adress = "Queens street 92" }
            };
            foreach (Trader c in traders)
            {
                context.Traders.Add(c);
            }
            context.SaveChanges();

            // Transactions
            var transactions = new Transaction[]
            {
                new Transaction { QuotationID = 1, TraderID = 00232 },
                new Transaction { QuotationID = 2, TraderID = 00426 },
                new Transaction { QuotationID = 1, TraderID = 00537 },
                new Transaction { QuotationID = 3, TraderID = 00956 },
                new Transaction { QuotationID = 3, TraderID = 00426 },
                new Transaction { QuotationID = 4, TraderID = 00232 },
                new Transaction { QuotationID = 5, TraderID = 00774 },
                new Transaction { QuotationID = 6, TraderID = 00956 },
                new Transaction { QuotationID = 6, TraderID = 00774 },
                new Transaction { QuotationID = 7, TraderID = 00232 },
                new Transaction { QuotationID = 5, TraderID = 00426 },
                new Transaction { QuotationID = 7, TraderID = 00537 }
            };
            foreach (Transaction e in transactions)
            {
                context.Transactions.Add(e);
            }
            context.SaveChanges();
        }
    }
}
