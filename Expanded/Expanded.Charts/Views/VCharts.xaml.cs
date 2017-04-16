using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BitcoinMyWallet.Helpers;
//using BitcoinMyWallet.ViewModels;
//using Bitcoin.APIClient;
using System.Net;
using Bitcoin.APIv2Client.Models;
using Expanded.Charts.ViewModels;
using Telerik.XamarinForms.Chart;
using Xamarin.Forms;
using Expanded.Charts.Models;

namespace Expanded.Charts.Views
{
    public partial class VCharts : TabbedPage
    {
        public VCharts()
        {
            InitializeComponent();
            ShowExchange();
            ShowCharts();
        }


        private async void ShowExchange()
        {
            var model = new ViewCharts(); // init base url
            var srollview = new ScrollView();
            var layout = new StackLayout();
            List<DataTricker> dataList = new List<DataTricker>();
            var label = new Label
            {
                TextColor = Color.Black,
                Text = "Currency 15m. Last Sell Buy",
                FontSize = 20
            };
            layout.Children.Add(label);

            dataList = await ViewCharts.GetMarketData();
            for (int i = 0; i < dataList.Count; i++)
            {
                var labelItem = new Label
                {
                    Text = $"{dataList[i].NameCurrency} {dataList[i].FifteenMinuts} {dataList[i].Buy} {dataList[i].Sell} {dataList[i].Buy}",
                    FontSize = 10
                };

                float result = i % 2;
                if (result > 0)
                {
                    labelItem.TextColor = Color.Blue;
                }
                else
                {
                    labelItem.TextColor = Color.Gray;
                }
                layout.Children.Add(labelItem);
            }


            srollview.Content = layout;
            this.exchanger.Content = srollview;
        }


        /// <summary>
        /// Async Method for show all chatrs
        /// </summary>
        private async void ShowCharts()
        {
            var model = new ViewCharts(); // init base url
            model.SetNewBaseUri();

            List<DataPointChart> dataList = new List<DataPointChart>();
            dataList = await ViewCharts.GetPointsData("total-bitcoins");
            this.ciculationBTC.Content = CreateChart(dataList);
            dataList = await ViewCharts.GetPointsData("market-price");
            this.marketPriceUSD.Content = CreateChart(dataList);
            dataList = await ViewCharts.GetPointsData("market-cap");
            this.marketCapatalization.Content = CreateChart(dataList);
            dataList = await ViewCharts.GetPointsData("trade-volume");
            this.exchangeTradeVolume.Content = CreateChart(dataList);
        }


        private async void ShowChartMarketPrice()
        {
            //var model = new ViewCharts();
            List <DataPointChart> dataList = new List<DataPointChart>();
            //model.DataFirstList = ViewCharts.GetPointsData("total-bitcoins");
            //model.DataSecondList = await ViewCharts.GetPointsData("market-price");
            dataList = await ViewCharts.GetPointsData("market-price");
            //model.DataThirdList = ViewCharts.GetPointsData("market-cap");
            //model.DataFourthList = ViewCharts.GetPointsData("trade-volume");

            this.marketPriceUSD.Content = CreateChart(dataList);
        }

        /// <summary>
        /// This method create one chart
        /// </summary>
        /// <param name="dataList">Specific data list</param>
        /// <returns>Chart</returns>
        private RadCartesianChart CreateChart(List<DataPointChart>  dataList)
        {
            var grid = new CartesianChartGrid();
            var chart = new RadCartesianChart
            {
                VerticalAxis = new NumericalAxis(),
                HorizontalAxis = new CategoricalAxis()
                {
                    LabelFitMode = AxisLabelFitMode.MultiLine,
                    PlotMode = AxisPlotMode.OnTicks
                },
                Grid = grid,
            };

            grid.MajorLinesVisibility = GridLineVisibility.Y;
            grid.MajorYLineDashArray = Device.OnPlatform(null, new double[] { 4, 2 }, new double[] { 4, 2 });
            grid.MajorLineColor = Color.FromHex("00357f");
            grid.MajorLineThickness = Device.OnPlatform(0.5, 2, 2);
            var series = new SplineAreaSeries();

            //series.ItemsSource = model.DataSecondList;
            series.ItemsSource = dataList;

            //series.CategoryBinding = new PropertyNameDataPointBinding
            //{
            //    PropertyName = "Date"
            //};

            series.ValueBinding = new PropertyNameDataPointBinding
            {
                PropertyName = "Value"
            };
            chart.Series.Add(series);

            return chart;
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
