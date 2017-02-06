using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.RPCClient.Responses;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class TranasctionDetailHelper
    {
        public static List<GetTransactionDetails> GetListTransactionDetails(string jsonData)
        {
            var jresult = JObject.Parse(jsonData).Property("result").Value.AsEnumerable();
            var jarray = JObject.Parse(jresult.ToString()).Property("details").Value.AsEnumerable();
            var data = JArray.Parse(jarray.ToString()).Children();

            var result = data.Select(d => new GetTransactionDetails
            {
                Fee = d.Value<decimal>("fee"),
                Amount = d.Value<decimal>("amount"),
                BlockIndex = d.Value<Int32>("blockindex"),
                Category = d.Value<string>("category"),
                Confirmations = d.Value<Int32>("confirmations"),
                Address = d.Value<string>("address"),
                TxId = d.Value<string>("txid"),
                Block = d.Value<long>("block"),
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
