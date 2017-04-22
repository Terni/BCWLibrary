using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using XLabs.Forms.Controls;

namespace Expanded.Charts.Views
{
    public partial class VCharts : TabbedPage
    {
        private Grid _tableGrid;

        public VCharts()
        {
            InitializeComponent();
            ShowExchange();
            ShowCharts();
        }

        private void GridRow(List<string> strList, Color color, int font, int indexRow)
        {
            _tableGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            for (int i = 0; i < 5; i++)
            {
                var label = new Label
                {
                    TextColor = color,
                    Text = strList[i],
                    FontSize = font
                };
                _tableGrid.Children.Add(label, i , indexRow);
            }

        }

        private async void ShowExchange()
        {
            var model = new ViewCharts(); // init base url
            var srollview = new ScrollView();
            _tableGrid = new Grid();
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            {// init Row
                List<string> strList = new List<string>
                {
                    "Curr.","15m.","Last","Sell","Buy"
                };
                GridRow(strList, Color.Black, 14, 0);
            }

            // download data from server
            List<DataTricker> dataList = new List<DataTricker>();
            dataList = await ViewCharts.GetMarketData();
            for (int i = 0; i < dataList.Count; i++)
            {
                List<string> marketList = new List<string>();
                marketList.Add(dataList[i].NameCurrency);
                marketList.Add(dataList[i].FifteenMinuts.ToString());
                marketList.Add(dataList[i].Buy.ToString());
                marketList.Add(dataList[i].Sell.ToString());
                marketList.Add(dataList[i].Buy.ToString());

                float result = i % 2;
                if (result > 0)
                {
                    GridRow(marketList, Color.Blue, 10, i+1);
                }
                else
                {
                    GridRow(marketList, Color.Gray, 10, i+1);
                }
            }


            srollview.Content = _tableGrid;
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

    }
}
