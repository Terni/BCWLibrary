using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Helpers;
using Bitcoin.APIv2Client.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Bitcoin.APIv2Client.ViewModels
{
    public class RatersPinMap
    {
        /// <summary>
        /// Method for get Rates for pins on the World
        /// </summary>
        /// <param name="jsonData">Specific json string</param>
        /// <returns>Result is List <see cref="DataPin"/></returns>
        public static List<DataPin> GetRates(string jsonData)
        {
            JObject data = JObject.Parse(jsonData);

            List<DataPin> datalist = new List<DataPin>();

            foreach (var obj in data.Properties().Select(p => p.Value))
            {

                var item =  new DataPin
                    {
                        Latitutde = (double)obj["lat"],
                        Longitude = (double)obj["long"],
                        Type = (string)obj["type"],
                        isTowway = (bool)obj["is_twoway"],
                        //Cryptos = CreateCryptosTList((string)obj["cryptos"]),
                        Url = (Uri)obj["url"]
                    };
                datalist.Add(item);
            } 
            //var values = JObject.Parse(jsonData).Property("values").Value.AsEnumerable();
            //var data =
            //    values.Select(
            //        d =>
            //            new DataPointChart
            //            {
            //                Date = d.Value<long>("x").ConvertFromUnixTimeStamp(),
            //                Value = d.Value<float>("y")
            //            }).ToList();

            return datalist;
        }

        private static List<CryptosType> CreateCryptosTList(string items)
        {
            List<CryptosType> result = new List<CryptosType>();
            var data = JObject.Parse(items);
            foreach (var it in data.Properties().Select(p => p.Value))
            {
                result.Add(it.Value<CryptosType>());
            }

            return result;
        }

    }
}