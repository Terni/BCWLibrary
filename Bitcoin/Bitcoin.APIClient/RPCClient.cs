// Copyright (c) 2014 Bc.Tomas Prokop
// Distributed under the GPLv3 software license.

// Inspirate from: Konstantin Ineshin, project from 2011

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bitcoin.APIClient
{
    public class ClassRpcClient : IRPCClient
    {
        #region Constructors
        public ClassRpcClient()
        {
        }

        public ClassRpcClient(string a_sUri)
        {
            Url = new Uri(a_sUri);
        }

        public ClassRpcClient(string a_sUri, String a_sUsr, String a_sPass)
        {
            Url = new Uri(a_sUri);
            GetUsernameUrl = a_sUsr;
            GetPasswordUrl = a_sPass;
        }
        #endregion

        #region Variables
        private static Uri Url;
        private String GetUsernameUrl;
        private String GetPasswordUrl;
        private ICredentials Credentials;

        private static String getParameters;
        public static String getResponseData;
        #endregion

        #region Private Methods Communication
        private static void SetBasicAuthHeader(WebRequest webRequest, String username, String password)
        {
            String authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.UTF8.GetBytes(authInfo));
            webRequest.Headers["Authorization"] = "Basic " + authInfo;
            //webRequest.Credentials = new NetworkCredential(username, password);
        }

        #region Testovani
        /// <summary>
        /// Testovaci mehoda.
        /// </summary>
        /// <param name="onResponseGot"></param>
        public void Post( Action<string> onResponseGot)
        {
            Uri uri = new Uri(Url.ToString());
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(uri);
            SetBasicAuthHeader(r, GetUsernameUrl, GetPasswordUrl);
            r.Method = "POST";


            r.BeginGetRequestStream(delegate(IAsyncResult req)
            {
                var outStream = r.EndGetRequestStream(req);

                using (StreamWriter w = new StreamWriter(outStream))
                    w.Write("{\"jsonrpc\": \"2.0\",\"id\": 1,\"method\": \"getinfo\",\"params\": []}");

                r.BeginGetResponse(delegate(IAsyncResult result)
                {
                    try
                    {
                        HttpWebResponse response = (HttpWebResponse)r.EndGetResponse(result);

                        using (var stream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                Debug.WriteLine(reader.ReadToEnd());
                                onResponseGot(reader.ReadToEnd());
                            }
                        }
                    }
                    catch
                    {
                        onResponseGot(null);
                    }

                }, null);

            }, null);
        }
        #endregion

        /// <summary> InvokeMethodRpc
        /// Methoda posle dotaz na Rpc server.
        /// </summary>
        /// <param name="a_sMethod">Methoda pro dotaz rpc.</param>
        /// <param name="a_sParams">Parametry pro methodu.</param>
        /// <returns>odpoved v jsonObject</returns>
        public JObject InvokeMethodRpc(string a_sMethod, params object[] a_sParams)
        {
            getParameters = "";
            //getResponseData = new JObject();

            //JObject errJObject = new JObject();

            try
            {

                // Set parameters
                JObject joe = new JObject();
                JArray props = new JArray();
                joe["jsonrpc"] = "2.0";
                joe["id"] = 1;
                joe["method"] = a_sMethod;

                if (a_sParams != null)
                {
                    if (a_sParams.Length > 0)
                    {

                        foreach (var p in a_sParams)
                        {
                            props.Add(p);
                        }

                    }
                    joe.Add(new JProperty("params", props));
                }

                // Vypis JSON hodnot
                Debug.WriteLine(joe);
                getParameters = JsonConvert.SerializeObject(joe);


                // parameters: name1=value1&name2=value2
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
                SetBasicAuthHeader(webRequest, GetUsernameUrl, GetPasswordUrl);

                // Set the ContentType property of the WebRequest.
                webRequest.ContentType = "application/json;charset=UTF-8";
                webRequest.Accept = "application/json";
                // Set the Method property of the request to POST.
                webRequest.Method = "POST";



                // start the asynchronous operation
                webRequest.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest);

                // Keep the main thread from continuing while the asynchronous
                // operation completes. A real world application
                // could do something useful such as updating its user interface.
                //allDone.WaitOne(1500);

                // asynchronously get a response
                //webRequest.BeginGetResponse(ResponseCallback, webRequest);
            }
            catch (WebException e)
            {
                Debug.WriteLine("\nException raised!");
                //MessageBox.Show(e.Message);
                Debug.WriteLine("\nStatus:{0}", e.Status);
                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("Source :{0} ", e.Source);
                //MessageBox.Show(e.Message);
                return null;
            }
            return null;
        } // end HttpPost_API

        /// <summary> GetRequestStreamCallback
        /// Methoda - Send data pomoci POST methods.
        /// </summary>
        /// <param name="asynchronousResult"></param>
        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            try
            { // send the Post

                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;

                // End the operation
                Stream postStream = request.EndGetRequestStream(asynchronousResult);

                // Convert the string into a byte array.
                byte[] byteArray = Encoding.UTF8.GetBytes(getParameters);

                // Write to the request stream.
                postStream.Write(byteArray, 0, getParameters.Length);
                postStream.Dispose();
                //postStream.Close();

                // Start the asynchronous operation to get the response
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);

            }
            catch (WebException e)
            {
                Debug.WriteLine("\nException raised!");
                //MessageBox.Show(e.Message);
                Debug.WriteLine("\nStatus:{0}", e.Status);
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("Source :{0} ", e.Source);
                //MessageBox.Show(e.Message);
            }
        }

        /// <summary> GetResponseCallback
        /// Methoda - Get data response
        /// </summary>
        /// <param name="asynchronousResult"></param>
        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            { // get the response

                HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
                // End the operation
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);

                // Set response data
                //getResponseData = JsonConvert.DeserializeObject<JObject>(streamRead.ReadToEnd());
                getResponseData = streamRead.ReadToEnd();
                Debug.WriteLine(streamRead.ReadToEnd());

                // Close the stream object
                streamResponse.Dispose();
                streamRead.Dispose();

                // Release the HttpWebResponse
                response.Dispose();
                //allDone.Set();
            }
            catch (WebException e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("\nStatus:{0}", e.Status);
                Debug.WriteLine(e.Message);

                //MessageBox.Show("It was found from the server. Perhaps you have a weak internet connection.");
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("Source :{0} ", e.Source);
                Debug.WriteLine(e.Message);

                //MessageBox.Show("It was found from the server. Perhaps you have a weak internet connection.");
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Zaloha uctu, pokud je zapnute zalohovani posle na Email, nebo je potreba povolit pristup Dropbox (musi byt prvne prihlasen),
        /// nebo je potreba povolit pristup GoogleDrive (musi byt prvne prihlasen).
        /// </summary>
        public void BackupWallet()
        {
            InvokeMethodRpc(RpcMethods.backupwallet.ToString());
        }

        /// <summary>
        /// Metoda ocekava Bitcoin adresu.
        /// Vraci: Label k adrese, jinak vraci chybu.
        /// </summary>
        /// <param name="a_address"></param>
        public void GetAccount(string a_address)
        {
            InvokeMethodRpc(RpcMethods.getaccount.ToString(), a_address);
        }

        /// <summary>
        /// Methoda ocekava Label.
        /// Vraci: Adresu ale pokud nebyl label nastaven tak vygeneruje novou adresu pro dany label.
        /// </summary>
        /// <param name="a_account"></param>
        public void GetAccountAddress(string a_account)
        {
            InvokeMethodRpc(RpcMethods.getaccountaddress.ToString(), a_account);
        }

        /// <summary>
        /// Mehoda ocekva Label.
        /// Vraci: Pole se vsemi shodovanymi.
        /// Pozor! Doporucuji nastavit GUID pro hlavni BitcoinAdresu, jinak nevraci nic.
        /// </summary>
        /// <param name="a_account"></param>
        public void GetAddressesByAccount(string a_account)
        {
            InvokeMethodRpc(RpcMethods.getaddressesbyaccount.ToString(), a_account) ;
        }

        /// <summary>
        /// Methoda vraci aktualni hodnotu menezenky ale pouze potvrzene transakce.
        /// </summary>
        /// <param name="a_account"></param>
        /// <param name="a_minconf"></param>
        public void GetBalance(string a_account = null, int a_minconf = 1)
        {
            if (a_account == null)
            {
                InvokeMethodRpc(RpcMethods.getbalance.ToString());
            }
            else
            {
                InvokeMethodRpc(RpcMethods.getbalance.ToString(), a_account, a_minconf);
            }

        }

        public string GetBlockByCount(int a_height)
        {
            return InvokeMethodRpc("getblockbycount", a_height)["result"].ToString();
        }

        public int GetBlockCount()
        {
            return (int)InvokeMethodRpc("getblockcount")["result"];
        }

        public int GetBlockNumber()
        {
            return (int)InvokeMethodRpc("getblocknumber")["result"];
        }

        public int GetConnectionCount()
        {
            return (int)InvokeMethodRpc("getconnectioncount")["result"];
        }

        public float GetDifficulty()
        {
            return (float)InvokeMethodRpc("getdifficulty")["result"];
        }

        public bool GetGenerate()
        {
            return (bool)InvokeMethodRpc("getgenerate")["result"];
        }

        public float GetHashesPerSec()
        {
            return (float)InvokeMethodRpc("gethashespersec")["result"];
        }

        /// <summary>
        /// Methoda vraci celkove informace k celemu uctu.
        /// </summary>
        public void GetInfo()
        {
            InvokeMethodRpc(RpcMethods.getinfo.ToString());
        }

        /// <summary>
        /// Methoda ocekva Label.
        /// Vraci: K labelu novou adresu.
        /// </summary>
        /// <param name="a_account"></param>
        public void GetNewAddress(string a_account)
        {
            InvokeMethodRpc(RpcMethods.getnewaddress.ToString(), a_account);
        }

        public float GetReceivedByAccount(string a_account, int a_minconf = 1)
        {
            return (float)InvokeMethodRpc("getreceivedbyaccount", a_account, a_minconf)["result"];
        }

        public float GetReceivedByAddress(string a_address, int a_minconf = 1)
        {
            return (float)InvokeMethodRpc("getreceivedbyaddress", a_address, a_minconf)["result"];
        }

        /// <summary>
        /// Methoda ocekva hash dane transakce.
        /// Vraci informace o transakci a pocet potvrzeni.
        /// </summary>
        /// <param name="a_txid"></param>
        public void GetTransaction(string a_txid)
        {
            InvokeMethodRpc(RpcMethods.gettransaction.ToString(), a_txid);
        }

        public JObject GetWork()
        {
            return InvokeMethodRpc("getwork")["result"] as JObject;
        }

        public bool GetWork(string a_data)
        {
            return (bool)InvokeMethodRpc("getwork", a_data)["result"];
        }

        public string Help(string a_command = "")
        {
            return InvokeMethodRpc("help", a_command)["result"].ToString();
        }

        public JObject ListAccounts(int a_minconf = 1)
        {
            return InvokeMethodRpc("listaccounts", a_minconf)["result"] as JObject;
        }

        public JArray ListReceivedByAccount(int a_minconf = 1, bool a_includeEmpty = false)
        {
            return InvokeMethodRpc("listreceivedbyaccount", a_minconf, a_includeEmpty)["result"] as JArray;
        }

        public JArray ListReceivedByAddress(int a_minconf = 1, bool a_includeEmpty = false)
        {
            return InvokeMethodRpc("listreceivedbyaddress", a_minconf, a_includeEmpty)["result"] as JArray;
        }

        /// <summary>
        /// Methoda ocekava Label penerenky
        /// null = vypise vsechny transakce ke vsem uctum v penezence
        /// Label = vraci pouze k damu labelu vsechny transakce
        ///
        /// Category jsou: send a receive
        /// </summary>
        /// <param name="a_account"></param>
        /// <param name="a_count"></param>
        public void ListTransactions(string a_account, int a_count = 10)
        {
            InvokeMethodRpc(RpcMethods.listtransactions.ToString(), a_account, a_count);
        }

        /// <summary>
        /// Methoda slouzi pro presun penez v ramci jedne peneznky na ruzne lably.
        /// </summary>
        /// <param name="a_fromAccount"></param>
        /// <param name="a_toAccount"></param>
        /// <param name="a_amount"></param>
        /// <param name="a_minconf"></param>
        /// <param name="a_comment"></param>
        /// <returns></returns>
        public bool Move(string a_fromAccount, string a_toAccount, float a_amount, int a_minconf = 1,
            string a_comment = "")
        {
            return (bool)InvokeMethodRpc(
            RpcMethods.move.ToString(),
            a_fromAccount,
            a_toAccount,
            a_amount,
            a_minconf,
            a_comment
            )["result"];
        }

        /// <summary>
        /// Methoda slouzi k poslani penez z daneho uctu na danou adresu.
        /// Hodnota ja ve travaru float.
        /// </summary>
        /// <param name="a_fromAccount"></param>
        /// <param name="a_toAddress"></param>
        /// <param name="a_amount"></param>
        /// <param name="a_minconf"></param>
        /// <param name="a_comment"></param>
        /// <param name="a_commentTo"></param>
        public void SendFrom(string a_fromAccount, string a_toAddress, float a_amount, int a_minconf = 1, string a_comment = "",
             string a_commentTo = "")
        {
            InvokeMethodRpc(RpcMethods.sendfrom.ToString(),a_fromAccount,a_toAddress,a_amount,a_minconf,a_comment,a_commentTo);
        }

        /// <summary>
        /// Methoda slouzi k poslani penez na danou adresu.
        /// Hodnota ja ve travaru decimal.
        /// </summary>
        /// <param name="a_address"></param>
        /// <param name="a_amount"></param>
        /// <param name="a_comment"></param>
        /// <param name="a_commentTo"></param>
        public void SendToAddress(string a_address, decimal a_amount, string a_comment, string a_commentTo)
        {
            InvokeMethodRpc(RpcMethods.sendtoaddress.ToString(), a_address, a_amount, a_comment, a_commentTo);
        }

        public void SetAccount(string a_address, string a_account)
        {
            InvokeMethodRpc("setaccount", a_address, a_account);
        }

        public void SetGenerate(bool a_generate, int a_genproclimit = 1)
        {
            InvokeMethodRpc("setgenerate", a_generate, a_genproclimit);
        }

        /// <summary>
        /// Methoda nastavi novy poplatek.
        /// </summary>
        /// <param name="a_address"></param>
        public void SetTxFee(double a_amount)
        {
            InvokeMethodRpc(RpcMethods.settxfee.ToString(), a_amount);
        }

        /// <summary>
        /// Methoda neni podporovana - na blockchain.info
        /// </summary>
        public void Stop()
        {
            InvokeMethodRpc("stop");
        }

        /// <summary>
        /// Methoda overi bitcoin adresu
        /// </summary>
        /// <param name="a_address"></param>
        public void ValidateAddress(string a_address)
        {
            InvokeMethodRpc(RpcMethods.validateaddress.ToString(), a_address);
        }

        /// <summary>
        /// Methoda pro zadani druheho hesla.
        /// </summary>
        /// <param name="a_pass"></param>
        /// <param name="a_timeout">Defaultne na 5 sekund.</param>
        public void WalletPassPhrase(string a_pass, int a_timeout = 5)
        {
            InvokeMethodRpc(RpcMethods.walletpassphrase.ToString(), a_pass, a_timeout);
        }

        /// <summary>
        /// Methoda neni podporovana - na blockchain.info
        /// </summary>
        /// <param name="a_passodl"></param>
        /// <param name="a_passnew"></param>
        public void WalletPassPhraseChange(string a_passodl, string a_passnew)
        {
            InvokeMethodRpc("walletpassphrasechange", a_passodl, a_passnew);
        }
        #endregion
    }
}
