using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using BitcoinWallet.Layers.Models;

namespace BitcoinWallet.Layers.Helpers
{
    public static class UriEngine
    {
        /// <summary>
        /// Proporty for MainUri
        /// </summary>
        public static Uri MainUri { get; set; }

        static UriEngine(){}

        /// <summary>
        /// Method for get Url and period
        /// </summary>
        /// <param name="address">Specific settings</param>
        /// <param name="bitcoinAddress">Specific your bitcoin address </param>
        /// <param name="format">Specific type <see cref="Arg.Formater"/> </param>
        /// <returns>Result is url or null</returns>
        public static Uri GetUriforTransaction(BaseApi.Type address, string bitcoinAddress, Arg.Formater format)
        {
            string args = $"{address}/";

            if (bitcoinAddress != null)
            {
                args += $"{bitcoinAddress}?format={format}";
                return new Uri(MainUri, args);
            }
            return null;
        }

    }
}
