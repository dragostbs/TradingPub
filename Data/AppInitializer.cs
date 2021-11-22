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

            // Quotations Forex
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

            // Quotations Crypto
            var crypto = new Crypto[]
            {
                new Crypto{Name="BTC/USD",Price=Decimal.Parse("57434.67")},
                new Crypto{Name="ETH/USD",Price=Decimal.Parse("4196.34")},
                new Crypto{Name="XRP/USD",Price=Decimal.Parse("1.04")},
                new Crypto{Name="LTC/USD",Price=Decimal.Parse("215.65")},
                new Crypto{Name="BCH/USD",Price=Decimal.Parse("564.15")},
                new Crypto{Name="IOT/USD",Price=Decimal.Parse("1.45")}
            };
            foreach (Crypto n in crypto)
            {
                context.Cryptos.Add(n);
            }
            context.SaveChanges();

            // Quotations Crypto
            var stocks = new Stocks[]
            {
                new Stocks{Name="Apple INC",Price=Decimal.Parse("160.55")},
                new Stocks{Name="NIO INC",Price=Decimal.Parse("38.66")},
                new Stocks{Name="Meta Platforms INC",Price=Decimal.Parse("345.30")},
                new Stocks{Name="Twitter INC",Price=Decimal.Parse("48.40")},
                new Stocks{Name="Microsoft CORP",Price=Decimal.Parse("343.11")},
                new Stocks{Name="Tesla INC",Price=Decimal.Parse("1137.06")},
                new Stocks{Name="Nvidia CORP",Price=Decimal.Parse("329.85")},
                new Stocks{Name="Pfizer INC",Price=Decimal.Parse("50.80")},
                new Stocks{Name="Ford Motors CO",Price=Decimal.Parse("19.39")},
                new Stocks{Name="Boeing CO",Price=Decimal.Parse("214.13")}
            };
            foreach (Stocks k in stocks)
            {
                context.Stocks.Add(k);
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
