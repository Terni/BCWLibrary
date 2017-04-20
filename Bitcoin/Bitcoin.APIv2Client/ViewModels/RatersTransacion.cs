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
    public class RatersTransacion
    {
        /// <summary>
        /// Method for get Rates for pins on the World
        /// </summary>
        /// <param name="jsonData">Specific json string</param>
        /// <returns>Result is List <see cref="DataPin"/></returns>
        public static List<DataTransaction> GetRates(string jsonData)
        {
            JObject data = JObject.Parse(jsonData);

            List<DataTransaction> datalist = new List<DataTransaction>();

            foreach (var obj in data.Properties().Select(p => p.Value))
            {

                var item =  new DataTransaction
                {
                        Latitutde = (double)obj["lat"],
                        Longitude = (double)obj["long"],
                        Type = (string)obj["type"],
                        isTowway = (bool)obj["is_twoway"],
                        //Cryptos = CreateCryptosTList((JObject)obj["cryptos"]),
                        Url = (Uri)obj["url"]
                    };
                datalist.Add(item);
            } 

            return datalist;
        }



    }
}