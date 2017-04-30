using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bitcoin.APIv2Client.NetStandard.Models;

namespace Bitcoin.APIv2Client.NetStandard.ViewModels
{
    public class RatesTicker
    {
        /// <summary>
        /// Method for get Rates for Market prices
        /// </summary>
        /// <param name="jsonData">Specific json string</param>
        /// <returns>Result is List <see cref="DataTricker"/></returns>
        public static List<DataTricker> GetRates(string jsonData)
        {
            JObject data = JObject.Parse(jsonData);
            List<DataTricker> result = new List<DataTricker>();
            string[] newArrays =
            {
                "USD", "JPY", "CNY", "SGD", "HKD", "CAD", "NZD", "AUD", "CLP", "GBP", "INR",
                "DKK", "SEK", "ISK", "CHF", "BRL", "EUR", "RUB", "PLN", "THB", "KRW", "TWD"
            };
            
            try
            {
                int i = 0;
                foreach (var obj in data.Properties().Select(p => p.Value))
                {
                    var idem = new DataTricker
                    {
                        NameCurrency = newArrays[i],
                        FifteenMinuts = (decimal)obj["15m"],
                        Last = (decimal)obj["last"],
                        Buy = (decimal)obj["buy"],
                        Sell = (decimal)obj["sell"],
                        Symbol = (string)obj["symbol"]
                    };
                    i++;
                    result.Add(idem);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Maybe bad size newArrays! Exception {e}");
            }

            return result;
        }
    }
}
