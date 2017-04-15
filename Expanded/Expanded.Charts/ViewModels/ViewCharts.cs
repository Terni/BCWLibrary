using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using Bitcoin.APIv2Client.ViewModels;
using Expanded.Charts.Helpers;
using Expanded.Charts.Models;
using System.Net.Http;

namespace Expanded.Charts.ViewModels
{
    public class ViewCharts
    {
        public IList DataFirstList { get; set; }
        public IList DataSecondList { get; set; }
        public IList DataThirdList { get; set; }
        public IList DataFourthList { get; set; }

        private static List<DataPointChart> _charts;

        public ViewCharts()
        {
            string startUrl = $"{BaseApi.ApiName}";
            UriEngine.MainUriChart = new Uri(startUrl);
        }

        public static async Task<List<DataPointChart>> GetPointsData(string namechart)
        {
            Tuple<int, ArgChart.Date> timespan = new Tuple<int, ArgChart.Date>(1, ArgChart.Date.year);
            Tuple<int, ArgChart.Date> rollingAverage = new Tuple<int, ArgChart.Date>(8, ArgChart.Date.hours);
            Uri newUri = UriEngine.GetUriforChart(BaseApi.Type.charts, namechart, timespan, rollingAverage, ArgChart.Formater.json);

            HttpClient client = new HttpClient();
            Debug.WriteLine(newUri.AbsoluteUri);
            string jsonData = await client.GetStringAsync(newUri);



            //return new List<DataPointChart>();
            return RatersChart.GetRates(jsonData);
        }



    }
}