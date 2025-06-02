using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class ValidityAddressHelper
    {
        public static Boolean GetValidAddress(string jsonData)
        {
            var jresult = JObject.Parse(jsonData).Property("result").Value.AsEnumerable();
            var jisvalid = JObject.Parse(jresult.ToString()).Property("isvalid").Value.AsEnumerable();
            var jvalue = jisvalid.Value<bool>();
            //var data = JArray.Parse(jarray.ToString()).Children();

            //var result = data.Select(d => new ListTransactionsResponse
            //{
            //    Fee = d.Value<decimal>("fee"),
            //    Amount = d.Value<decimal>("amount"),
            //    BlockIndex = d.Value<double>("blockindex"),
            //    Time = d.Value<double>("time"),
            //    Category = d.Value<string>("category"),
            //    Confirmations = d.Value<decimal>("confirmations"),
            //    Address = d.Value<string>("address"),
            //    TxId = d.Value<string>("txid"),
            //    BlockHash = d.Value<string>("blockhash"),
            //    Account = d.Value<string>("account"),
            //    Label = d.Value<string>("label")
            //}).ToList();

            return jvalue;

        }

    }
}
