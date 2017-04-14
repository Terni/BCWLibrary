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