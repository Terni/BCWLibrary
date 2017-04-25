using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using BitcoinWallet.Layers.Helpers;
using BitcoinWallet.Layers.Models;
using BitcoinWallet.Layers.ViewModels;
using Xamarin.Forms;
using Info.Blockchain.API.BlockExplorer;

namespace BitcoinWallet.Views
{
    public partial class VHistory : TabbedPage
    {
        private int SatoshiPerBitcoin { get; set; }

        public VHistory()
        {
            InitializeComponent();
            SatoshiPerBitcoin = BitcoinValue.SatoshisPerBitcoin;
            ShowRecieveAndSendTrans();
        }

        /// <summary>
        /// Method for Show Recieve and Send Transaction in History max. 50 records
        /// </summary>
        public async void ShowRecieveAndSendTrans()
        {
            var recieveScrollView = new ScrollView();
            var recieveLayout = new StackLayout();
            var sendScrollView = new ScrollView();
            var sendLayout = new StackLayout();
            List<TransRow> listTrans = new List<TransRow>();

            listTrans = await GetListTranstion();
            if (listTrans.Count > 0) // test for count
            {
                foreach (var trans in listTrans)
                {
                    if (trans.Type == TypeTrans.Recieve) // For RECIEVE
                    {
                        var frame = new Frame { OutlineColor = Color.Green };
                        var labelAddrress = new Label
                        {
                            Text = $"{trans.BitcoinAddress} \n{trans.Date}",
                            TextColor = Color.Green,
                            FontSize = 10
                        };
                        frame.Content = labelAddrress;
                        recieveLayout.Children.Add(frame);

                        float resultValue = (float)trans.Value / SatoshiPerBitcoin; //SatoshisPerBitcoin = 100000000
                        Debug.WriteLine($"vysledek prichozi: {resultValue}");
                        var labelValue = new Label
                        {
                            Text = $"{resultValue} BTC",
                            TextColor = Color.Green,
                            FontSize = 14
                        };

                        recieveLayout.Children.Add(labelValue);
                    }
                    else // For SEND
                    {
                        var frame = new Frame { OutlineColor = Color.Red };
                        var labelAddrress = new Label
                        {
                            Text = $"{trans.BitcoinAddress} \n{trans.Date}",
                            TextColor = Color.Red,
                            FontSize = 10
                        };
                        frame.Content = labelAddrress;
                        sendLayout.Children.Add(frame);

                        float resultValue = (float)trans.Value / SatoshiPerBitcoin; //SatoshisPerBitcoin = 100000000
                        Debug.WriteLine($"vysledek odchozi: -{resultValue}");
                        var labelValue = new Label
                        {
                            Text = $"-{resultValue} BTC",
                            TextColor = Color.Red,
                            FontSize = 14
                        };
                        sendLayout.Children.Add(labelValue);
                    }
                }

                // Show all labels
                recieveScrollView.Content = recieveLayout;
                this.receiveHistory.Content = recieveScrollView;
                sendScrollView.Content = sendLayout;
                this.sendHistory.Content = sendScrollView;
            }
        }

        /// <summary>
        /// Method for get List all transaction max. 50 records
        /// </summary>
        /// <returns>Result is list transaction</returns>
        private async Task<List<TransRow>> GetListTranstion()
        {
            DataTransaction dataTransaction = new DataTransaction();
            List<TransRow> listTrans = new List<TransRow>();
            dataTransaction = await ViewTransaction.GetTransactionData();  //update data

            if (dataTransaction.ListTransactions.Count > 0) // test for count
            {
                BalanceHelper.DataTransactiontTrans = dataTransaction;
            }
            else // from chace data
            {
                if (BalanceHelper.DataTransactiontTrans.ListTransactions.Count > 0) 
                {
                    dataTransaction = BalanceHelper.DataTransactiontTrans;
                }
            }
            
            if (dataTransaction.ListTransactions.Count > 0) // test for count
            {
                foreach (var transaction in dataTransaction.ListTransactions)
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
                    listTrans.Add(item);
                }
            }

            return listTrans;
        }

    }
}
