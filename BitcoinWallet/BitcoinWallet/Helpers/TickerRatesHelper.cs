using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using BitcoinWallet.ViewModels;
using BitcoinMyWallet.ViewModels;
using Bitcoin.APIClient;

namespace BitcoinMyWallet.Helpers
{
    public class TickerRatesHelper
    {
        public static ClassWebClient Client;

        public static List<TickerRateValue> GetRatesValue(string jsonData)
        {
            JObject data = JObject.Parse(jsonData);
            List<TickerRateValue> result = new List<TickerRateValue>();
            string[] newaArray =
            {
                "USD", "CNY", "JPY", "SGD", "HKD", "CAD", "NZD", "AUD", "CLP", "GBP",
                "DKK", "SEK", "ISK", "CHF", "BRL", "EUR", "RUB", "PLN", "THB", "KRW", "TWD"
            };

            int i = 0;
            foreach (var obj in data.Properties().Select(p => p.Value))
            {
                var idem = new TickerRateValue
                {
                    NameCurrency = newaArray[i],
                    FifteenMinuts = (decimal)obj["15m"],
                    Last = (decimal)obj["last"],
                    Buy = (decimal)obj["buy"],
                    Sell = (decimal)obj["sell"]
                };
                i++;
                result.Add(idem);
            }

            return result;
        }
    }
}
