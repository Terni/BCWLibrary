using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Core;

namespace BitcoinWallet.Helpers
{
    public static class XmlList
    {
        private static List<Modules> ListModules { get; set; }

        /// <summary>
        /// Method for Set all properties
        /// </summary>
        /// <param name="list"></param>
        public static void SetXmlList(List<Modules> list)
        {
            ListModules = list; // local list modules

            foreach (var item in list)
            {
                if (item.Name == $"{Modules.TypName.api_bing_maps}")
                {
                    BingApiKey = item.Value;
                }
                if (item.Name == $"{Modules.TypName.api_google_maps}")
                {
                    GoogleApiKey = item.Value;
                }
                if (item.Name == $"{Modules.TypName.api_code}")
                {
                    ApiCode =  item.Value;
                }
            }
        }

        public static string BingApiKey { get; set; }

        public static string GoogleApiKey { get; set; }

        public static string ApiCode { get; set; }

    }
}
