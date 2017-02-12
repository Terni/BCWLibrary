using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinMyWallet.Helpers;
using BitcoinMyWallet.ViewModels;
using Bitcoin.APIClient;
using System.Net;

using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VCharts : TabbedPage
    {
        public VCharts()
        {
            //InitializeComponent();




            //TickerRatesHelper.Client = new WebClient();
            //TickerRatesHelper.Client.DownloadStringCompleted += ClientOnDownloadStringCompleted_Rate;
            //TickerRatesHelper.Client.DownloadStringAsync(GlobalParamas.UrlTicker);
        }

        /*
        private void ClientOnDownloadStringCompleted_Rate(object sender, DownloadStringCompletedEventArgs downloadStringCompletedEventArgs)
        {
            var dataSource = new TickerRateValue();
            //var data = dataSource.USD.Buy;
            var resultDataRates = TickerRatesHelper.GetRatesValue(downloadStringCompletedEventArgs.Result);

            ListBoxRates.Items.Clear();
            for (int i = 0; i < resultDataRates.Count; i++) // Loop through List with for
            {
                var itemRates = resultDataRates[i];

                TextBlock ratesLabel = new TextBlock();
                ratesLabel.FontSize = 35;
                ratesLabel.FontWeight = FontWeights.Bold;
                ratesLabel.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                ratesLabel.Text = itemRates.NameCurrency;

                TextBlock rates15 = new TextBlock();
                //rates15.TextWrapping = TextWrapping.Wrap;
                //rates.FontStyle = FontStyles.Italic;
                rates15.Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 180, 255));
                rates15.Text = "  " + itemRates.FifteenMinuts;
                TextBlock ratesLast = new TextBlock();
                //ratesLast.TextWrapping = TextWrapping.Wrap;
                //rates.FontStyle = FontStyles.Italic;
                ratesLast.Margin = new Thickness(130, -25, 0, 0);
                ratesLast.Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 180, 255));
                ratesLast.Text = itemRates.Last.ToString();
                TextBlock ratesSell = new TextBlock();
                //ratesSell.TextWrapping = TextWrapping.Wrap;
                //rates.FontStyle = FontStyles.Italic;
                ratesSell.Margin = new Thickness(240, -25, 0, 0);
                ratesSell.Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 180, 255));
                ratesSell.Text = itemRates.Sell.ToString();
                TextBlock ratesBuy = new TextBlock();
                //ratesBuy.TextWrapping = TextWrapping.Wrap;
                //rates.FontStyle = FontStyles.Italic;
                ratesBuy.Margin = new Thickness(350, -25, 0, 0);
                ratesBuy.Foreground = new SolidColorBrush(Color.FromArgb(255, 50, 180, 255));
                ratesBuy.Text = itemRates.Buy.ToString();

                ListBoxRates.Items.Add(ratesLabel);
                ListBoxRates.Items.Add(rates15);
                ListBoxRates.Items.Add(ratesLast);
                ListBoxRates.Items.Add(ratesSell);
                ListBoxRates.Items.Add(ratesBuy);

            }
        }*/
    }
}
