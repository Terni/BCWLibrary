using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.Abstractions;
using Info.Blockchain.API.Wallet;
using Info.Blockchain.API;
using Info.Blockchain.API.BlockExplorer;


namespace Bitcoin.APIv2Client.ViewModels
{
    public class ClientApi
    {
        private readonly BlockchainApiHelper _blockchainApi;
        private Uri BaseUrl { get; set; }
        private string ApiCode { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiCode">Specific apicode after create base url</param>
        /// <param name="serviceUrl">Specific for service url</param>
        public ClientApi(string apiCode, Uri serviceUrl = null)
        {
            ApiCode = apiCode;
            BaseUrl = serviceUrl;
            if (serviceUrl == null)
            {
                _blockchainApi = new BlockchainApiHelper(ApiCode);
            }
            else
            {
                // Only pro service = Create new wallet
                _blockchainApi = new BlockchainApiHelper(ApiCode, null, BaseUrl.AbsolutePath);
            }
        }

        /// <summary>
        /// Method for set your wallet
        /// </summary>
        /// <param name="idwallet">Specific identifier current wallet</param>
        /// <param name="pass">Decrypted first password</param>
        /// <param name="passtwo">Decrypted second password</param>
        public WalletHelper GetWallet(string idwallet, string pass, string passtwo = null)
        {
            return _blockchainApi.CreateWalletHelper(identifier: idwallet, password: pass, secondPassword: passtwo);
        }

    }
}
