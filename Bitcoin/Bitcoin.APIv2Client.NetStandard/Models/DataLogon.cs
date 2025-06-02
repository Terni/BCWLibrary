using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.NetStandard.Models
{
    public static class DataLogon
    {
        private static string _addressWallet = "1ExSUAx9yjXqbMGzM8bAuSU3yHbR8SQyd4";  // TODO for testing

        public static string IdWallet { get; set; }

        public static string AddressWallet
        {
            get { return _addressWallet; }
            set { _addressWallet = value; }
        }

        public static string Password { get; set; }
        public static string PasswordSecond { get; set; }

        public static string ApiCode { get; set; }
    }
}
