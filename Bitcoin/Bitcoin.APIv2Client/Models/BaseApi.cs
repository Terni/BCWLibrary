using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.Models
{
    public static class BaseApi
    {
        public const string BaseName = "https://blockchain.info/";
        public const string BaseNameInfoApi = "https://blockchain.info";
        public const string ApiName = "https://api.blockchain.info/";
        public const string MapsApiName = "https://coinatmradar.com/api/locations/1990-01-01/";

        //public const int SatoshisPerBitcoin = 100000000;
        public const int fee = 10000; // = fee/SatoshisPerBitcoin = 0,0001 fee for miners

        /// <summary>
        /// Examples:
        /// 
        /// Charts = https://api.blockchain.info/charts/xxxxx?timespan=5weeks&rollingAverage=8hours&format=json
        ///        = xxxx is specific name for chart
        ///        = https://api.blockchain.info/charts/transactions-per-second?timespan=5weeks&rollingAverage=8hours&format=json
        ///        = https://api.blockchain.info/charts/market-price?timespan=5weeks&rollingAverage=8hours&format=json
        ///        = all is https://blockchain.info/charts
        /// 
        /// History = https://blockchain.info/address/$bitcoin_address?format=json
        /// 
        /// Maps = https://coinatmradar.com/api/locations/ 
        /// Maps = https://coinatmradar.com/api/locations/<date_from>/ 
        /// Maps = https://coinatmradar.com/api/locations/<date_from>/<date_to>/ 
        /// 
        /// Ticker = https://blockchain.info/ticker
        /// 
        /// Stats = https://api.blockchain.info/stats
        /// 
        /// Pools = https://api.blockchain.info/pools?timespan=5days
        ///       = max 10 days
        /// </summary>
        public enum Type
        {
            charts = 0,
            stats = 1,
            pools = 2,
            ticker = 3,
            address = 4
        }

        
    }
}
