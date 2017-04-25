using Bitcoin.APIv2Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.ViewModels;
using System.Net.Http;

namespace BitcoinWallet.Layers.ViewModels
{
    public class ViewAtmsShops
    {
        private static Uri BaseUrl { get; set; }

        public ViewAtmsShops()
        {
            string startUrl = $"{BaseApi.MapsApiName}";
            BaseUrl = new Uri(startUrl);
        }

        public static async Task<List<DataPin>> GetPinsData()
        {


            HttpClient client = new HttpClient();
            Debug.WriteLine(BaseUrl.AbsoluteUri);
            string jsonData = string.Empty;
            try
            {
                jsonData = await client.GetStringAsync(BaseUrl);
            }
            catch
            {
                throw new Exception("Error in client.GetStringAsynch, maybe bad url address or params!");
                //Logging.Debug("Start app.", Logging.Level.DATABASE); // TODO vyresit kruhovou referenci na Logging
            }

            return RatersPinMap.GetRates(jsonData);
        }
    }
}
