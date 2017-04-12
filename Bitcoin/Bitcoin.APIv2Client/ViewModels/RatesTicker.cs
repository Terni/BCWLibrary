using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bitcoin.APIv2Client.Models;

namespace Bitcoin.APIv2Client.ViewModels
{
    public class RatesTicker
    {
        //public static ClassWebClient Client;

        public static List<DataTricker> GetRates(string jsonData)
        {
            JObject data = JObject.Parse(jsonData);
            List<DataTricker> result = new List<DataTricker>();
            string[] newaArray =
            {
                "USD", "CNY", "JPY", "SGD", "HKD", "CAD", "NZD", "AUD", "CLP", "GBP",
                "DKK", "SEK", "ISK", "CHF", "BRL", "EUR", "RUB", "PLN", "THB", "KRW", "TWD"
            };

            int i = 0;
            foreach (var obj in data.Properties().Select(p => p.Value))
            {
                var idem = new DataTricker
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
