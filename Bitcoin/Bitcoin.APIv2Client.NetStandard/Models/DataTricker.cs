using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.NetStandard.Models
{
    public enum Curency
    {
        USD, CNY, JPY, SGD, HKD, CAD, NZD, AUD, CLP, GBP, DKK, SEK, ISK, CHF, BRL, EUR, RUB, PLN, THB, KRW, TWD
    }

    public class DataTricker
    {
        public String NameCurrency { get; set; }
        public Decimal FifteenMinuts { get; set; }
        public Decimal Last { get; set; }
        public Decimal Buy { get; set; }
        public Decimal Sell { get; set; }
        public String Symbol { get; set; }
    }
}

//{
//  "USD" : {"15m" : 449.56, "last" : 449.56, "buy" : 449.59, "sell" : 450.72,  "symbol" : "$"},
//  "CNY" : {"15m" : 2793.41, "last" : 2793.41, "buy" : 2793.59, "sell" : 2800.61,  "symbol" : "¥"},
//  "JPY" : {"15m" : 45773.48, "last" : 45773.48, "buy" : 45776.53, "sell" : 45891.59,  "symbol" : "¥"},
//  "SGD" : {"15m" : 561.33, "last" : 561.33, "buy" : 561.37, "sell" : 562.78,  "symbol" : "$"},
//  "HKD" : {"15m" : 3484.84, "last" : 3484.84, "buy" : 3485.08, "sell" : 3493.84,  "symbol" : "$"},
//  "CAD" : {"15m" : 489.5, "last" : 489.5, "buy" : 489.53, "sell" : 490.76,  "symbol" : "$"},
//  "NZD" : {"15m" : 521.91, "last" : 521.91, "buy" : 521.95, "sell" : 523.26,  "symbol" : "$"},
//  "AUD" : {"15m" : 480.22, "last" : 480.22, "buy" : 480.26, "sell" : 481.46,  "symbol" : "$"},
//  "CLP" : {"15m" : 251314.83, "last" : 251314.83, "buy" : 251331.6, "sell" : 251963.3,  "symbol" : "$"},
//  "GBP" : {"15m" : 266.77, "last" : 266.77, "buy" : 266.79, "sell" : 267.46,  "symbol" : "£"},
//  "DKK" : {"15m" : 2436.97, "last" : 2436.97, "buy" : 2437.13, "sell" : 2443.26,  "symbol" : "kr"},
//  "SEK" : {"15m" : 2952.05, "last" : 2952.05, "buy" : 2952.25, "sell" : 2959.67,  "symbol" : "kr"},
//  "ISK" : {"15m" : 50429.84, "last" : 50429.84, "buy" : 50433.21, "sell" : 50559.97,  "symbol" : "kr"},
//  "CHF" : {"15m" : 398.16, "last" : 398.16, "buy" : 398.19, "sell" : 399.19,  "symbol" : "CHF"},
//  "BRL" : {"15m" : 995.49, "last" : 995.49, "buy" : 995.56, "sell" : 998.06,  "symbol" : "R$"},
//  "EUR" : {"15m" : 326.74, "last" : 326.74, "buy" : 326.76, "sell" : 327.59,  "symbol" : "€"},
//  "RUB" : {"15m" : 15829.04, "last" : 15829.04, "buy" : 15830.1, "sell" : 15869.89,  "symbol" : "RUB"},
//  "PLN" : {"15m" : 1365.11, "last" : 1365.11, "buy" : 1365.2, "sell" : 1368.63,  "symbol" : "zł"},
//  "THB" : {"15m" : 14662.21, "last" : 14662.21, "buy" : 14663.19, "sell" : 14700.04,  "symbol" : "฿"},
//  "KRW" : {"15m" : 460431.86, "last" : 460431.86, "buy" : 460462.59, "sell" : 461619.92,  "symbol" : "₩"},
//  "TWD" : {"15m" : 13556.29, "last" : 13556.29, "buy" : 13557.19, "sell" : 13591.27,  "symbol" : "NT$"}

//}