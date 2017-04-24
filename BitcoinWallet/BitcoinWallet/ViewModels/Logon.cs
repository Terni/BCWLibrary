using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using Info.Blockchain.API;
using Info.Blockchain.API.Wallet;
using Bitcoin.APIv2Client.ViewModels;
using BitcoinWallet.Layers.Helpers;
using BitcoinWallet.Layers.Models;
using Info.Blockchain.API.BlockExplorer;

namespace BitcoinWallet.ViewModels
{
    public class Logon
    {
        public static string ApiCode { get; set; }
        public static string IdentifierWallet { get; set; }
        public static string Password { get; set; }
        public static string PasswordSecond { get; set; }
        public static int Balance { get; set; }

        public Logon()
        {
            ClientApi _client = new ClientApi(ApiCode, null, new Uri(BaseApi.BaseNameInfoApi));
            ApiLogon.Wallet = _client.GetWallet(IdentifierWallet, Password, PasswordSecond);
        }

        //public async Task<BitcoinValue> GetBalance()
        //{
        //    return await Wallet.GetBalanceAsync();
        //}

        //public async Task<Info.Blockchain.API.Wallet.Address> GetAddress(string address, int conf = 0)
        //{
        //    return await Wallet.GetAddressAsync(address, confirmations: conf);
        //}

        //public async Task<List<Info.Blockchain.API.Wallet.Address>> GetAddressList(int conf = 0)
        //{
        //    return await Wallet.ListAddressesAsync(confirmations: conf);
        //}

        //public async Task<PaymentResponse> SendMoney(string toAddress, BitcoinValue amount, string fromAddress = null, BitcoinValue? fee = null, string note = null)
        //{
        //    if (fee == null)
        //    {
        //        fee = new BitcoinValue(BaseApi.fee);
        //    }

        //    return await Wallet.SendAsync(toAddress, amount, fromAddress, fee, note);
        //}

    }
}
