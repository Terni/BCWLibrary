﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using BitcoinWallet.Layers.Models;
using BitcoinWallet.Layers.ViewModels;
using Xamarin.Forms;
using Info.Blockchain.API.BlockExplorer;

namespace BitcoinWallet.Views
{
    public partial class VHistory : TabbedPage
    {
        public string BitcoinAddres { get; set; }

        public VHistory()
        {
            InitializeComponent();

            ShowRecieveAndSendTrans();
        }

        /// <summary>
        /// Method for Show Recieve and Send Transaction in History max. 50 records
        /// </summary>
        private async void ShowRecieveAndSendTrans()
        {
            var recieveScrollView = new ScrollView();
            var recieveLayout = new StackLayout();
            var sendScrollView = new ScrollView();
            var sendLayout = new StackLayout();
            List<TransRow> listTrans = new List<TransRow>();

            listTrans = await GetListTranstion();
            foreach (var trans in listTrans)
            {
                if (trans.Type == TypeTrans.Recieve) // For RECIEVE
                {
                    var labelAddrress = new Label
                    {
                        Text = $"{trans.BitcoinAddress}",
                        TextColor = Color.Green,
                        FontSize = 10
                    };
                    recieveLayout.Children.Add(labelAddrress);

                    decimal resultValue = trans.Value / BitcoinValue.SatoshisPerBitcoin; //SatoshisPerBitcoin = 100000000
                    var labelValue = new Label
                    {
                        Text = $"{resultValue}", 
                        TextColor = Color.Green,
                        FontSize = 14
                    };
                    recieveLayout.Children.Add(labelValue);
                }
                else // For SEND
                {
                    var labelAddrress = new Label
                    {
                        Text = $"{trans.BitcoinAddress}",
                        TextColor = Color.Red,
                        FontSize = 10
                    };
                    sendLayout.Children.Add(labelAddrress);

                    decimal resultValue = trans.Value / BitcoinValue.SatoshisPerBitcoin; //SatoshisPerBitcoin = 100000000
                    var labelValue = new Label
                    {
                        Text = $"{resultValue}",
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
            this.receiveHistory.Content = sendScrollView;
        }

        /// <summary>
        /// Method for get List all transaction max. 50 records
        /// </summary>
        /// <returns>Result is list transaction</returns>
        private async Task<List<TransRow>> GetListTranstion()
        {
            List<DataTransaction> dataList = new List<DataTransaction>();
            List<TransRow> listTrans = new List<TransRow>();


            dataList = await ViewTransaction.GetTransactionData();
            for (int i = 0; i < dataList.Count; i++)
            {
                //TODO: zde bude if pro pridavani


                var item = new TransRow
                {
                    BitcoinAddress = "",
                    Type = TypeTrans.Recieve, // or TypeTrans.Send
                    Value = 0
                };

                listTrans.Add(item);
            }

            return listTrans;
        }

    }
}
