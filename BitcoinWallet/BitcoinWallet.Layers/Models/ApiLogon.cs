using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.BlockExplorer;
using Info.Blockchain.API.Wallet;

namespace BitcoinWallet.Layers.Models
{
    public static class ApiLogon
    {
        public static string ApiCode { get; set; }
        public static string IdentifierWallet { get; set; }
        public static string FromMyBitcoinAddress { get; set; }
        public static string ToBitcoinAddress { get; set; }
        public static double MyAmount { get; set; }
        public static string Password { get; set; }
        public static string PasswordSecond { get; set; }

        public static BitcoinValue Balance { get; set; }

        /// <summary>
        /// Property for <see cref="Info.Blockchain.API.Wallet.Address"/>
        /// </summary>
        public static Info.Blockchain.API.Wallet.Address Address { get; set; }

        public static List<Info.Blockchain.API.Wallet.Address> AddressList { get; set; }

        /// <summary>
        /// Property for <see cref="WalletHelper"/>
        /// </summary>
        public static WalletHelper Wallet { get; set; }

        public static PaymentResponse PayResponse { get; set; }

    }
}
