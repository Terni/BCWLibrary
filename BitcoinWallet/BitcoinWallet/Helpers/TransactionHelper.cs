using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.RPCClient.RequestResponse;
using Bitcoin.RPCClient.Responses;
using BitcoinMyWallet.ViewModels;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class TransactionHelper
    {
        //private static List<ListTransactionsResponse> getListTransactions;

        //public static JsonResponse GetResult(string jsonData)
        //{
        //    var idem = new JsonResponse
        //    {
        //        Id = (int)JObject.Parse(jsonData).Property("id");
        //        Result = (string)JObject.Parse(jsonData).Property("result").Value;
        //        Error = (string)JObject.Parse(jsonData).Property("error").Value;
        //        JsonRpc = (float)JObject.Parse(jsonData).Property("jsonrpc").Value;
        //    };
        //    return idem;
        //}

        //public static JsonResponseResult GetResultValue(string jsonData)
        //{
        //    JObject data = JObject.Parse(jsonData);
        //    JsonResponseResult result = new JsonResponseResult();

        //    foreach (var obj in data.Properties().Select(p => p.Value))
        //    {
        //        var idem = new JsonResponseResult
        //        {
        ////            LastBlock = (string)obj["lastblock"],
        //            Transactions = (string)obj["transactions"]
        //        };
        //        result = idem;
        //    }

        //    return result;
        //}

        public static List<ListTransactionsResponse> GetListTransaction(string jsonData)
        {
            var jresult = JObject.Parse(jsonData).Property("result").Value.AsEnumerable();
            var jarray = JObject.Parse(jresult.ToString()).Property("transactions").Value.AsEnumerable();
            var data = JArray.Parse(jarray.ToString()).Children();

            var result = data.Select(d => new ListTransactionsResponse
            {
                Fee = d.Value<decimal>("fee"),
                Amount = d.Value<decimal>("amount"),
                BlockIndex = d.Value<double>("blockindex"),
                Time = d.Value<long>("time"),
                Category = d.Value<string>("category"),
                Confirmations = d.Value<decimal>("confirmations"),
                Address = d.Value<string>("address"),
                TxId = d.Value<string>("txid"),
                BlockHash = d.Value<string>("blockhash"),
                Account = d.Value<string>("account"),
                Label = d.Value<string>("label")
            }).ToList();


            //var obj = (JObject)JsonConvert.DeserializeObject(json);
            //var nodes = obj["transactions"].Children()
            //            .Select(node => new
            //            {
            //                Fee = (decimal)node["fee"],
            //                Amount = (decimal)node["title"],
            //                BlockIndex = (double)node["blockindex"],
            //                Time = (double)node["time"],
            //                Category = (string)node["category"],
            //                Confirmations = (uint)node["confirmations"],
            //                Address = (string)node["address"],
            //                TxId = (string)node["txid"],
            //                BlockHash = (string)node["blockhash"],
            //                Account = (string)node["account"],
            //                Label = (string)node["label"],
            //            })
            //            .ToList();


            return result;
        }
    }
}
