using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using Bitcoin.APIv2Client.ViewModels;
using BitcoinWallet.Layers.Helpers;
using BitcoinWallet.Layers.Models;

namespace BitcoinWallet.Layers.ViewModels
{
    public static class ViewTransaction
    {
        private static Uri BaseUrl { get; set; }
        public static string BitcoinAddres { get; set; }

        static ViewTransaction()
        {
            string startUrl = $"{BaseApi.BaseName}";
            UriEngine.MainUri = new Uri(startUrl);
            BitcoinAddres = DataLogon.AddressWallet;
        }

        public static async Task<DataTransaction> GetTransactionData()
        {
            HttpClient client = new HttpClient();
            Uri BaseUrl = UriEngine.GetUriforTransaction(BaseApi.Type.address, BitcoinAddres, Arg.Formater.json);
            if (BaseUrl == null)
            {
                return new DataTransaction();
            }

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

            return RatersTransacion.GetRates(jsonData);
        }

    }
}
