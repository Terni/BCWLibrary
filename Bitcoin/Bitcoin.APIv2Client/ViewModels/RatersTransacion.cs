using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Helpers;
using Bitcoin.APIv2Client.Models;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Bitcoin.APIv2Client.ViewModels
{
    public class RatersTransacion
    {
        /// <summary>
        /// Method for get Rates for pins on the World
        /// </summary>
        /// <param name="jsonData">Specific json string</param>
        /// <returns>Result is List <see cref="DataPin"/></returns>
        public static DataTransaction GetRates(string jsonData)
        {
            var obj = JToken.Parse(jsonData);


            //JToken obj =  data.Properties().Select(p => p.Value);
            try
            {
                var dataTrx = new DataTransaction
                {
                    Hash160 = (string)obj["hash160"],
                    Address = (string)obj["address"],
                    NumberTransaction = (int)obj["n_tx"],
                    TotalRecived = (long)obj["total_received"],
                    TotalSent = (long)obj["total_sent"],
                    FinalBalance = (long)obj["final_balance"],
                    ListTransactions = GetListTransaction(obj["txs"])
                };
                return dataTrx;
            }
            catch (Exception e)
            {
                return new DataTransaction();
                //throw new Exception($"Maybe is bad key for parsing! Exception {e}");
            }
        }

        private static List<Transaction> GetListTransaction(JToken trans)
        {
            List<Transaction> listTransactions = new List<Transaction>();
            foreach (var oneTx in trans)
            {
                //For INPUTS
                List<InputRow> inputsList = new List<InputRow>();
                {
                    string innerInputs = oneTx["inputs"].Value<JToken>().ToString();
                    JObject prevOut = JObject.Parse(innerInputs.Trim('[', ']'));

                    var input = new InputRow
                    {
                        PrevOut = GetOutRow(JToken.Parse(prevOut["prev_out"].ToString()))
                    };
                    inputsList.Add(input);
                }
                
                //For Transaction
                JToken innerOuts = oneTx["out"].Value<JToken>();
                var item = new Transaction
                {
                    ListInputs = inputsList, //inputs
                    TupleOuts = new Tuple<OutRow, OutRow>(GetOutRow(innerOuts.First), GetOutRow(innerOuts.First.Next)) //outs
                };
                listTransactions.Add(item);

            }
            return listTransactions;
        }

        private static OutRow GetOutRow(JToken row)
        {
            return new OutRow
            {
                Spent = (bool) row["spent"],
                TxIndex = (long) row["tx_index"],
                Type = (int) row["type"],
                Address = (string) row["addr"],
                Value = (long) row["value"],
                Number = (int) row["n"],
                Script = (string) row["script"]
            };
        }

        //public class OutRow
        //{
        //    public bool Spent { get; set; }
        //    public long TxIndex { get; set; }
        //    public int Type { get; set; }
        //    public string Address { get; set; }
        //    public long Value { get; set; }
        //    public int Number { get; set; } //n
        //    public string Script { get; set; }
        //}

        //public class InputRow
        //{
        //    public long Sequence { get; set; }
        //    public OutRow PrevOut { get; set; }
        //    public string Script { get; set; }
        //}

        //public class Transaction
        //{
        //    public int Ver { get; set; }
        //    public List<InputRow> ListInputs { get; set; }
        //    public long BlockHeight { get; set; }
        //    public string RelayedBy { get; set; }
        //    public Tuple<OutRow, OutRow> TupleOuts { get; set; }
        //    public string LockTime { get; set; }
        //    public double Result { get; set; }
        //    public long Size { get; set; }
        //    public string Time { get; set; }
        //    public long TxIndex { get; set; }
        //    public int VinSz { get; set; }
        //    public string Hash { get; set; }
        //    public int VoutSz { get; set; }
        //}

        //private static List<CryptosType> CreateCryptosTList(JObject items)
        //{
        //    List<CryptosType> result = new List<CryptosType>();
        //    foreach (var it in items)
        //    {
        //        if (it.Key == CryptosType.bitcoin.ToString() && it.Value.ToString() == "1")
        //            result.Add(CryptosType.bitcoin);
        //        if (it.Key == CryptosType.dogecoin.ToString() && it.Value.ToString() == "1")
        //            result.Add(CryptosType.dogecoin);
        //        if (it.Key == CryptosType.litecoin.ToString() && it.Value.ToString() == "1")
        //            result.Add(CryptosType.litecoin);
        //        if (it.Key == CryptosType.ether.ToString() && it.Value.ToString() == "1")
        //            result.Add(CryptosType.ether);
        //    }
        //    return result;
        //}

    }
}