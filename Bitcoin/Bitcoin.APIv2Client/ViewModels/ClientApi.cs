using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.Abstractions;
using Info.Blockchain.API.Wallet;
using Info.Blockchain.API;
using Info.Blockchain.API.BlockExplorer;
using System.Net.Http;
using Bitcoin.APIv2Client.Models;
using Bitcoin.APIv2Client.Helpers;

namespace Bitcoin.APIv2Client.ViewModels
{
    public class ClientApi
    {
        private BlockchainApiHelper _blockchainApi;
        private IHttpClient BaseUrl { get; set; }
        private Uri ServiceUrl { get; set; }
        private string ApiCode { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="apiCode">Specific apicode after create base url</param>
        /// <param name="serviceUrl">Specific for service url</param>
        public ClientApi(string apiCode, Uri baseUrl = null, Uri serviceUrl = null)
        {
            ApiCode = apiCode;
            ServiceUrl = serviceUrl;

            if (baseUrl == null && serviceUrl == null)
            {
                _blockchainApi = new BlockchainApiHelper(ApiCode);
            }
            else
            {
                if (BaseUrl != null)
                {
                    BaseUrl = new BlockchainHttpClient(ApiCode, baseUrl.AbsoluteUri);
                    // Only pro service = Create new wallet
                    // second param autocreate baseUrl with https://blockchain.info
                    _blockchainApi =
                        new BlockchainApiHelper(ApiCode, BaseUrl, ServiceUrl.AbsoluteUri); // TODO mozna dopsat jeste dalsi metody
                }
                else
                {
                    _blockchainApi =
                        new BlockchainApiHelper(ApiCode, null, ServiceUrl.AbsoluteUri);
                }
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
