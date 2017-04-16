using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net;
using Bitcoin.APIv2Client.NetStandard.Helpers;
using Bitcoin.APIv2Client.NetStandard.Models;

namespace Bitcoin.APIv2Client.NetStandard.ViewModels
{
    public class RatersChart
    {
        //public static ClassWebClient Client;

        public static List<DataPointChart> GetRates(string jsonData)
        {
            var values = JObject.Parse(jsonData).Property("values").Value.AsEnumerable();
            var data =
                values.Select(
                    d =>
                        new DataPointChart
                        {
                            Date = d.Value<long>("x").ConvertFromUnixTimeStamp(),
                            Value = d.Value<float>("y")
                        }).ToList();

            return data;
        }
    }
}