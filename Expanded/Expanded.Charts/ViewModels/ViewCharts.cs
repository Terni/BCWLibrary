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

        /// <summary>
        /// Constructor for init Base Url
        /// </summary>
        public ViewCharts()
        {
            string startUrl = $"{BaseApi.BaseName}";
            UriEngine.MainUriChart = new Uri(startUrl);
        }

        public void SetNewBaseUri()
        {
            string startUrl = $"{BaseApi.ApiName}";
            UriEngine.MainUriChart = new Uri(startUrl);
        }

        public void SetNewBaseUri(string name)
        {
            string startUrl = $"{name}";
            UriEngine.MainUriChart = new Uri(startUrl);
        }

        public static async Task<List<DataTricker>> GetMarketData()
        {
            Uri newUri = UriEngine.GetUriforChart(BaseApi.Type.ticker);

            HttpClient client = new HttpClient();
            Debug.WriteLine(newUri.AbsoluteUri);
            string jsonData = string.Empty;
            try
            {
                jsonData = await client.GetStringAsync(newUri);
            }
            catch
            {
                //throw new Exception("Error in client.GetStringAsynch, maybe bad url address or params!");
                //Logging.Debug("Start app.", Logging.Level.DATABASE); // TODO vyresit kruhovou referenci na Logging

                Debug.WriteLine("Error in client.GetStringAsynch, maybe bad url address or params!");
                return new List<DataTricker>(); // empty data
            }

            return RatesTicker.GetRates(jsonData);
        }


        /// <summary>
        /// Method for all points one year
        /// </summary>
        /// <param name="namechart">Specific name chart</param>
        /// <returns>Result is list points</returns>
        public static async Task<List<DataPointChart>> GetPointsData(string namechart)
        {
            Tuple<int, ArgChart.Date> timespan = new Tuple<int, ArgChart.Date>(1, ArgChart.Date.year);
            Tuple<int, ArgChart.Date> rollingAverage = new Tuple<int, ArgChart.Date>(8, ArgChart.Date.hours);
            Uri newUri = UriEngine.GetUriforChart(BaseApi.Type.charts, namechart, timespan, rollingAverage, ArgChart.Formater.json);

            HttpClient client = new HttpClient();
            Debug.WriteLine(newUri.AbsoluteUri);
            string jsonData = string.Empty;
            try
            {
                jsonData = await client.GetStringAsync(newUri);
            }
            catch
            {
                //throw new Exception("Error in client.GetStringAsynch, maybe bad url address or params!");
                //Logging.Debug("Start app.", Logging.Level.DATABASE); // TODO vyresit kruhovou referenci na Logging

                Debug.WriteLine("Error in client.GetStringAsynch, maybe bad url address or params!");
                return new List<DataPointChart>(); // empty data
            }

            List<DataPointChart> selectedList = new List<DataPointChart>();
            selectedList = DateSelector(RatersChart.GetRates(jsonData));
            return selectedList;
            //return RatersChart.GetRates(jsonData);
        }

        /// <summary>
        /// Method for Selected list points
        /// </summary>
        /// <param name="notSelectedList">Not Selected List</param>
        /// <returns>Result is Selected list</returns>
        private static List<DataPointChart> DateSelector(List<DataPointChart> notSelectedList)
        {
            List<DataPointChart> selectedList = new List<DataPointChart>();
            int step = notSelectedList.Count / 20; // specific step for Date and Value
            for (int i = 0; i < notSelectedList.Count; )
            {
                selectedList.Add(notSelectedList[i]);
                i = i + step;
            }

            return selectedList;
        }


    }
}