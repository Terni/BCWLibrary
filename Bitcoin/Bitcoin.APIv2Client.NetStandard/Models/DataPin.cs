using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.NetStandard.Models
{
    public enum CryptosType
    {
        bitcoin = 0,
        litecoin = 1,
        dogecoin = 2,
        ether = 3
    }

    public class DataPin
    {
        public double Latitutde { get; set; }
        public double Longitude { get; set; }
        public string Type { get; set; }
        public bool isTowway { get; set; }
        public List<CryptosType> Cryptos { get; set; }
        public Uri Url { get; set; }
    }
}
