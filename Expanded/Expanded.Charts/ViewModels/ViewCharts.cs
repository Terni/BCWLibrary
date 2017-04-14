using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using Bitcoin.APIv2Client.ViewModels;


namespace Expanded.Charts.ViewModels
{
    public class ViewCharts
    {
        public IList DataOneList { get; set; }
        public IList DataTwoList { get; set; }


        //private Uri UrlTicker = "";
        private Uri UrlmarketPriceUSD = "";


        private static List<DataPointChart> _charts;

        public ViewCharts()
        {

        }

        public static List<DataPointChart> GetCategoricalData()
        {
            string jsonData = string.Empty;

            return RatersChart.GetRates(jsonData);
        }

    }
}