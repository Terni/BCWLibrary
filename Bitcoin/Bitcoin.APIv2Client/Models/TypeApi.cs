using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.Models
{
    public static class BaseApi
    {
        public static readonly string ApiName = "https://api.blockchain.info/";
        public static readonly string MarketName = "https://blockchain.info/";
        public static readonly string MapsApiName = "https://coinatmradar.com/api/locations/1990-01-01/";
        public enum Type
        {
            charts = 0,
            stats = 1,
            pools = 2,
            ticker = 3
        }
    }
}
