using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BitcoinMyWallet.Models;
using BitcoinMyWallet.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class RatesHelper
    {
        public static WebClient Client;

        public static List<DateTimeValueChartDataPoint> GetRates(string jsonData)
        {
            var values = JObject.Parse(jsonData).Property("values").Value.AsEnumerable();
            var data =
                values.Select(
                    d =>
                        new DateTimeValueChartDataPoint
                        {
                            Date = d.Value<long>("x").DateTimeFromUnixTimestamp(),
                            Value = d.Value<float>("y")
                        }).ToList();

            return data;
        }
    }
}
