using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API;
using Info.Blockchain.API.Wallet;
using Bitcoin.APIv2Client.ViewModels;
using Info.Blockchain.API.BlockExplorer;

namespace BitcoinWallet.ViewModels
{
    public class Logon
    {
        public static string ApiCode { get; set; }
        public static string IdentifierWallet { get; set; }
        public static string Password { get; set; }
        public static string PasswordSecond { get; set; }

        /// <summary>
        /// Property pro <see cref="WalletHelper"/>
        /// </summary>
        public WalletHelper Wallet { get; set; }

        public BitcoinValue Balance { get; set; }
        public Info.Blockchain.API.Wallet.Address Address { get; set; }

        public Logon()
        {
            ClientApi _client = new ClientApi(ApiCode);
            Wallet = _client.GetWallet(IdentifierWallet, Password, PasswordSecond);

            
        }

        //public async Task<BitcoinValue> GetBalance()
        //{
        //    return await Wallet.GetBalanceAsync();
        //}

        //public async Task<Info.Blockchain.API.Wallet.Address> GetAddress(string address)
        //{
        //    return await Wallet.GetAddressAsync(address);
        //}

        //public async Task<PaymentResponse> SendMoney(string toAddress, BitcoinValue amount, string fromAddress = null, BitcoinValue? fee = null, string note = null)
        //{
        //    return await Wallet.SendAsync(toAddress, amount, fromAddress, fee, note);
        //}

    }
}
