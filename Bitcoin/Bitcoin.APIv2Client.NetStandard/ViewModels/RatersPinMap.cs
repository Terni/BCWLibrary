using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.NetStandard.Helpers;
using Bitcoin.APIv2Client.NetStandard.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Bitcoin.APIv2Client.NetStandard.ViewModels
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
                        //Cryptos = CreateCryptosTList((JObject)obj["cryptos"]),
                        Url = (Uri)obj["url"]
                    };
                datalist.Add(item);
            } 

            return datalist;
        }

        /// <summary>
        /// Method for create list <see cref="CryptosType"/> from one line in items
        /// </summary>
        /// <param name="items">Specific line for json</param>
        /// <returns>Result is list <see cref="CryptosType"/></returns>
        private static List<CryptosType> CreateCryptosTList(JObject items)
        {
            List<CryptosType> result = new List<CryptosType>();
            foreach (var it in items)
            {
                if (it.Key == CryptosType.bitcoin.ToString() && it.Value.ToString() == "1")
                    result.Add(CryptosType.bitcoin);
                if (it.Key == CryptosType.dogecoin.ToString() && it.Value.ToString() == "1")
                    result.Add(CryptosType.dogecoin);
                if (it.Key == CryptosType.litecoin.ToString() && it.Value.ToString() == "1")
                    result.Add(CryptosType.litecoin);
                if (it.Key == CryptosType.ether.ToString() && it.Value.ToString() == "1")
                    result.Add(CryptosType.ether);
            }

            return result;
        }

    }
}