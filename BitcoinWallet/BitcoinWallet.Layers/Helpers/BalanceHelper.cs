using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using BitcoinWallet.Layers.Models;
using Xamarin.Forms;
using Info.Blockchain.API.BlockExplorer;
using BitcoinWallet.Layers.ViewModels;

namespace BitcoinWallet.Layers.Helpers
{
    public class BalanceHelper
    {
        public List<TransRow> ListTrans { get; set; }

        public static DataTransaction DataTransactiontTrans { get; set; }

        public BalanceHelper()
        {
            ListTrans = new List<TransRow>();
            GetListTranstion();
        }


        public async Task<DataTransaction> GetDataTransactiontTrans()
        {
            DataTransactiontTrans = new DataTransaction();
            DataTransactiontTrans = await ViewTransaction.GetTransactionData();
            return DataTransactiontTrans;
        }

        /// <summary>
        /// Method for get List all transaction max. 50 records
        /// </summary>
        /// <returns>Result is list transaction</returns>
        private async void GetListTranstion()
        {
            DataTransactiontTrans = new DataTransaction();
            DataTransactiontTrans = await ViewTransaction.GetTransactionData();
            if (DataTransactiontTrans.ListTransactions.Count > 0) // test for count
            {
                foreach (var transaction in DataTransactiontTrans.ListTransactions)
                {
                    TransRow item;

                    if (string.Compare(transaction.ListInputs[0].PrevOut.Address,
                            transaction.TupleOuts.Item2.Address) == 0) // is True = Send Transaction
                    {
                        item = new TransRow
                        {
                            BitcoinAddress = transaction.TupleOuts.Item1.Address, // where send is here
                            Type = TypeTrans.Send, // or TypeTrans.Send
                            Value = transaction.TupleOuts.Item1.Value,
                            Date = transaction.Time
                        };
                    }
                    else // is False = Recieve Transaction
                    {
                        item = new TransRow
                        {
                            BitcoinAddress = transaction.TupleOuts.Item1.Address, // where recieve is here
                            Type = TypeTrans.Recieve, // or TypeTrans.Send
                            Value = transaction.TupleOuts.Item1.Value,
                            Date = transaction.Time
                        };
                    }

                    //Debug.WriteLine($"zapis hodnoty: {item.Value}");
                    ListTrans.Add(item);
                }
            }
        }

    }
}
