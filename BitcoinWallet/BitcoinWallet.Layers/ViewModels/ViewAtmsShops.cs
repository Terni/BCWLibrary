using Bitcoin.APIv2Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.ViewModels;
using System.Net.Http;
using BitcoinWallet.Layers.Helpers;

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
            Debug.WriteLine(BaseUrl.AbsoluteUri);
            string jsonData = string.Empty;
            try
            {
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(60); //60s max
                jsonData = await client.GetStringAsync(BaseUrl);
            }
            catch
            {
                //throw new Exception("Error in client.GetStringAsynch, maybe bad url address or params!");
                //Logging.Debug("Start app.", Logging.Level.DATABASE); // TODO vyresit kruhovou referenci na Logging

                Debug.WriteLine("Error in client.GetStringAsynch, maybe bad url address or params!");

                try
                {
                    using (StreamReader reader = new StreamReader(new LoadJsonFile().Streams))
                    {
                        string chaceJsonData = reader.ReadToEnd();
                        return RatersPinMap.GetRates(chaceJsonData);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error in chace data from file.json!");
                    return new List<DataPin>(); //return empty data
                }
            }
            return RatersPinMap.GetRates(jsonData);
        }

        public static async Task<List<DataPin>> GetPinsDataAndroid()
        {

            string jsonData = string.Empty;
            try
            {
                using (StreamReader reader = new StreamReader(new LoadJsonFile().Streams))
                {
                    string chaceJsonData = reader.ReadToEnd();
                    return RatersPinMap.GetRates(chaceJsonData);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in chace data from file.json!");
                return new List<DataPin>(); //return empty data
            }
            return RatersPinMap.GetRates(jsonData);
        }
    }
}
