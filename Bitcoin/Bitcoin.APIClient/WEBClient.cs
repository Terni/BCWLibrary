// Copyright (c) 2014 Bc.Tomas Prokop
// Distributed under the GPLv3 software license.

using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Security.Policy;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace Bitcoin.APIClient
{
    public class ClassWebClient : IWEBClient
    {

        #region Constants
        #region Constants Methods
        private const string METOD_PAY = "/payment?";
        private const string METHO_SEND_MANY = "/sendmany?";
        private const string METOD_BALANCE = "/balance?";
        private const string METOD_BALANCE_ADDR = "/address_balance?";
        private const string METOD_LIST = "/list?";
        private const string METOD_NEW_ADDR = "/new_address?";
        private const string METOD_ARCHIVE_ADDR = "/archive_address?";
        private const string METOD_UNARCHIVE_ADDR = "/unarchive_address?";
        private const string METOD_AUTO_CON = "/auto_consolidate?";
        #endregion

        #region Constants Default setting
        const string MY_CONFIRM = "6"; // minimalni pocet potvrzeni
        const string MY_AMOUNT = "0";
        const string SHARED = "false";
        const string FEE = "0.0001"; // minimalni poplatek jinak se neprovede transakce
        string NOTE = "";
        #endregion
        #endregion

        #region Constructor
        /// <summary> constructor
        /// </summary>
        public ClassWebClient()
        {

        }

        /// <summary> constructor
        /// </summary>
        /// <param name="a_sUri"> Get URL for Payment.</param>
        public ClassWebClient(string a_sUri)
        {
            getUrl = new Uri(a_sUri);
        }

        /// <summary> constructor
        /// </summary>
        /// <param name="a_sUri"> Get URL for Payment.</param>
        /// <param name="a_sUsr"> Get User GUID.</param>
        /// <param name="a_sPass"> Get User Password.</param>
        public ClassWebClient(string a_sUri, String a_sUsr, String a_sPass)
        {
            getUrl = new Uri(a_sUri);
            getUsername = a_sUsr;
            getPassword = a_sPass;
            //MessageBox.Show("test");
        }

        /// <summary> constructor
        /// </summary>
        /// <param name="a_sUri"> Get URL for Payment.</param>
        /// <param name="a_sUsr"> Get User GUID.</param>
        /// <param name="a_sPass"> Get User Password.</param>
        /// <param name="a_sPassTwo"> Get User Second Password.</param>
        public ClassWebClient(string a_sUri, String a_sUsr, String a_sPass, String a_sPassTwo )
        {
            getUrl = new Uri(a_sUri);
            getUsername = a_sUsr;
            getPassword = a_sPass;
            getSecondPassword = a_sPassTwo;
        }

        /// <summary> constructor
        /// </summary>
        /// <param name="a_sUri"> Get URL for Payment.</param>
        /// <param name="a_sUsr"> Get User GUID.</param>
        /// <param name="a_sPass"> Get User Password.</param>
        /// <param name="a_sPassTwo"> Get User Second Password.</param>
        /// <param name="a_sAddress"> Get User Address.</param>
        public ClassWebClient(string a_sUri, String a_sUsr, String a_sPass, String a_sPassTwo, String a_sAddress)
        {
            getUrl = new Uri(a_sUri);
            getUsername = a_sUsr;
            getPassword = a_sPass;
            getSecondPassword = a_sPassTwo;
            getMyAddress = a_sAddress;
        }

        /// <summary> constructor
        /// </summary>
        /// <param name="a_sUri"> Get URL for Payment.</param>
        /// <param name="a_sUsr"> Get User GUID.</param>
        /// <param name="a_sPass"> Get User Password.</param>
        /// <param name="a_sPassTwo"> Get User Second Password.</param>
        /// <param name="a_sAddress"> Get User Address.</param>
        /// <param name="a_sToAdress"> Get Bitcoint address, where i send my money BTC.</param>
        public ClassWebClient(string a_sUri, String a_sUsr, String a_sPass, String a_sPassTwo, String a_sAddress,
            String a_sToAdress)
        {
            getUrl = new Uri(a_sUri);
            getUsername = a_sUsr;
            getPassword = a_sPass;
            getSecondPassword = a_sPassTwo;
            getMyAddress = a_sAddress;
            getToAddress = a_sToAdress;
        }

        #endregion

        #region Variables
        private Uri getUrl;
        private String getUsername;
        private String getPassword;
        private String getSecondPassword;
        private String getMyAddress;
        private String getToAddress;

        private static String getParameters;
        public static String getResponseData;
        #endregion


        #region Delegates
        /// <summary>
        /// Callback action when the data is ready
        /// </summary>
        //private static ManualResetEvent allDone = new ManualResetEvent(false);
        //public delegate void GetResponseDL(string message);
        //public event GetResponseDL ResponseTargetEvent;
        #endregion

        #region Private Methods Communication

        #region Test HttpClient
        /// <summary>
        /// Metoda provede dotaz na webove rozhrani.
        /// </summary>
        /// <param name="uri">url adresa</param>
        /// <param name="parameters">parametry pro metodu POST.</param>
        /// <returns></returns>
        public void InvokeMethodHttpClient(String uri, String parameters)
        {
            var allUrl = uri + parameters;
            DoPost(allUrl);
        }

        /// <summary>
        /// Testovaci methoda DoPost Async
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<String> DoPost(String uri)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri));
            //StringContent content;
            //using (var ms = new MemoryStream())
            //{
            //    var ser = new DataContractSerializer(typeof(T));
            //    ser.WriteObject(ms, data);
            //    ms.Position = 0;
            //    content = new StringContent(new StreamReader(ms).ReadToEnd());
            //}

            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            //request.Headers.TransferEncodingChunked = true;
            HttpResponseMessage response = await client.SendAsync(request);
            var outResponse = await response.Content.ReadAsStringAsync();
            var outParser = await Task.Run(() => JObject.Parse(outResponse));
            Debug.WriteLine(outParser.First);
            return outResponse;
        }
        #endregion

        /// <summary> InvokeMethodWeb
        /// Methoda pro pripojeni api ansynchronizacne
        /// <para>URI - is http url address. </para>
        /// <para>Parametrs - for method post. </para>
        /// </summary>
        public String InvokeMethodWeb(String uri, String parameters)
        {
            //getResponseData = "";

            try
            {
                // parameters: name1=value1&name2=value2
                HttpWebRequest webRequest_new = (HttpWebRequest) WebRequest.Create(uri);

                // Set the Method property of the request to POST.
                webRequest_new.Method = "POST";

                // Set the ContentType property of the WebRequest.
                webRequest_new.ContentType = "application/x-www-form-urlencoded";
                //webRequest.ContentType = "application/json";

                // Set parameters

                getParameters = parameters;

                // start the asynchronous operation
                webRequest_new.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), webRequest_new);

                // Keep the main thread from continuing while the asynchronous
                // operation completes. A real world application
                // could do something useful such as updating its user interface.
                //allDone.WaitOne(1500);
            }
            catch ( WebException e )
            {
                Debug.WriteLine("\nException raised!");
                //MessageBox.Show(e.Message);
                Debug.WriteLine("\nStatus:{0}", e.Status);
                return e.Message;
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("Source :{0} ", e.Source);
                //MessageBox.Show(e.Message);
                return e.Message;
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

                // Start the asynchronous operation to get the response
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), request);

            }
            catch (WebException e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("\nMessage:{0}", e.Message);
                Debug.WriteLine("\nStatus:{0}", e.Status);
            }
            catch (Exception e)
            {
                Debug.WriteLine("\nException raised!");
                Debug.WriteLine("Source :{0} ", e.Source);
                Debug.WriteLine("Message :{0} ", e.Message);
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
                //GetResponseAnsynchro(streamRead.ReadToEnd().Trim());

                string outing = streamRead.ReadToEnd();
               // Console.WriteLine(responseString);
                getResponseData = outing;
                //Debug.WriteLine("Vystup:");
                Debug.WriteLine(outing);

                //if (outing != String.Empty)
                //{
                //    ResponseTargetEvent(outing);
                //}

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

        /// <summary>
        /// Methoda nastavi privatni hodnoty z odpovedi.
        /// </summary>
        /// <param name="sr"></param>
        //private static void GetResponseAnsynchro(Object sr)
        //{
        //    getResponseData = sr;
        //}

        #endregion

        #region Public Methods
        /// <summary> GetBalance
        /// </summary>
        public void GetBalance()
        {
            //balance?password=$main_password
            string uris = getUrl + getUsername + METOD_BALANCE;
            string pars = pars = "password=" + getPassword;

            InvokeMethodWeb(uris, pars);
        }

        /// <summary> GetAddressBalance
        /// </summary>
        public void GetAddressBalance()
        {
            if(getMyAddress == "")
            {
                //MessageBox.Show("Error: Bitcoin address for Methodu \"Balance\" is empty!");
            }

            //address_balance?password=$main_password&address=$address&confirmations=$confirmations
            string uris = getUrl + getUsername + METOD_BALANCE_ADDR;
            string pars = "password=" + getPassword + "&address=" + getMyAddress + "&confirmations=" + MY_CONFIRM;

            InvokeMethodWeb(uris, pars);
        }

        /// <summary> GetAddressList
        /// </summary>
        public void GetAddressList()
        {
            //list?password=$main_password
            string uris = getUrl + getUsername + METOD_LIST;
            string pars = "password=" + getPassword;

            InvokeMethodWeb(uris, pars);
        }

        /// <summary> SetPayment
        /// </summary>
        public void SetPayment()
        {
            if (getToAddress == "")
            {
                //MessageBox.Show("Error: Bitcoin send address for \"Methodu Payment\" is empty!");
            }

            //payment?password=$main_password&second_password=$second_password&to=$address&amount=$amount&from=$from&shared=$shared&fee=$fee&note=$note
            string uris = getUrl + getUsername + METOD_PAY;
            string pars = "";
            if (getSecondPassword != String.Empty)
            {// Kdyz druhe heslo je nastaveno.
                if (getMyAddress != String.Empty)
                {// Kdyz moje adresa je nastavena.
                    pars = "main_password=" + getPassword + "&second_password=" + getSecondPassword + "&to=" + getToAddress +
                           "&amount=" + MY_AMOUNT + "&from=" + getMyAddress + "&shared=" + SHARED;
                }
                else
                {
                    pars = "main_password=" + getPassword + "&second_password=" + getSecondPassword + "&to=" + getToAddress +
                           "&amount=" + MY_AMOUNT + "&shared=" + SHARED;
                }


            }
            else
            {
                if (getMyAddress != String.Empty)
                {// Kdyz moje adresa je nastavena.
                    pars = "" + "main_password=" + getPassword + "&to=" + getToAddress + "&amount=" + MY_AMOUNT +
                           "&from=" + getMyAddress + "&shared=" + SHARED;
                }
                else
                {
                    pars = "" + "main_password=" + getPassword + "&to=" + getToAddress + "&amount=" + MY_AMOUNT +
                           "&shared=" + SHARED;
                }
            }


            InvokeMethodWeb(uris, pars);
        }

        /// <summary> SetNewAddress
        /// </summary>
        public void SetNewAddress(String getNewLabel)
        {
            if (getNewLabel == "")
            {
                //MessageBox.Show("Error: Label for \"Methodu New Address\" is empty!");
            }

            //new_address?password=$main_password&second_password=$second_password&label=$label
            string uris = getUrl + getUsername + METOD_NEW_ADDR;
            string pars = "";
            if (getSecondPassword != String.Empty)
            {// Kdyz druhe heslo je nastaveno.
                pars = "main_password=" + getPassword + "&second_password=" + getSecondPassword + "&label=" +
                       getNewLabel;
            }
            else
            {
                pars = "main_password=" + getPassword + "&label=" + getNewLabel;
            }

            InvokeMethodWeb(uris, pars);
        }

        /// <summary> SetArchiveAddress
        /// </summary>
        public void SetArchiveAddress(String getAddress)
        {
            if (getAddress == "")
            {
                //MessageBox.Show("Warring: Address \"Methodu Archive Address\" is empty!");
            }

            //archive_address?password=$main_password&second_password=$second_password&address=$address
            string uris = getUrl + getUsername + METOD_ARCHIVE_ADDR;
            string pars = "";
            if (getSecondPassword != String.Empty)
            {// Kdyz druhe heslo je nastaveno.
                pars = "main_password=" + getPassword + "&second_password=" + getSecondPassword + "&address=" +
                       getAddress;
            }
            else
            {
                pars = "main_password=" + getPassword + "&address=" + getAddress;
            }

            InvokeMethodWeb(uris, pars);
        }

        /// <summary> SetUnarchiveAddress
        /// </summary>
        public void SetUnarchiveAddress(String getAddress)
        {
            if (getAddress == "")
            {
                //MessageBox.Show("Warring: Address \"Methodu UnArchive Address\" is empty!");
            }

            //unarchive_address?password=$main_password&second_password=$second_password&address=$address
            string uris = getUrl + getUsername + METOD_UNARCHIVE_ADDR;
            string pars = "";
            if (getSecondPassword != String.Empty)
            {// Kdyz druhe heslo je nastaveno.
                pars = "main_password=" + getPassword + "&second_password=" + getSecondPassword + "&address=" +
                       getAddress;
            }
            else
            {
                pars = "main_password=" + getPassword + "&address=" + getAddress;
            }

            InvokeMethodWeb(uris, pars);
        }

        /// <summary> GetStats
        /// </summary>
        public void GetStats()
        {
            //muze byt libovolna funkce
            string uris = getUrl.ToString();
            string pars = "";

            InvokeMethodWeb(uris, pars);
        }
        #endregion
    }
}
