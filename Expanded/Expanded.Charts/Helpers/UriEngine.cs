using Expanded.Charts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;

namespace Expanded.Charts.Helpers
{
    public static class UriEngine
    {
        /// <summary>
        /// Proporty for MainUri
        /// </summary>
        public static Uri MainUriChart { get; set; }

         static UriEngine(){}

        /// <summary>
        /// Method for get Url only TypeChart
        /// </summary>
        /// <param name="typechart">Specific type chart</param>
        /// <returns>Result is url with TypeChart</returns>
        public static Uri GetUriforChart(BaseApi.Type typechart)
        {
            string args = $"{typechart}";
            return GetUriforChart(typechart, null);
        }

        /// <summary>
        /// Method for get Url and period
        /// </summary>
        /// <param name="typechart">Specific type chart</param>
        /// <param name="timespan">Specific Date value for period </param>
        /// <returns>Result is url with TypeChart and period</returns>
        public static Uri GetUriforChart(BaseApi.Type typechart, Tuple<int, ArgChart.Date> timespan)
        {   
            string args = $"{typechart}";

            if (timespan != null)
            {
                args += "?";
                args += $"&timespan={timespan.Item1}{timespan.Item2}";
            }
            return new Uri(MainUriChart, args);
        }

        /// <summary>
        /// Method for get Url all params
        /// </summary>
        /// <param name="typechart">Specific type chart</param>
        /// <param name="namechart">Spefific name chart</param>
        /// <param name="timespan">Specific Date value for period </param>
        /// <param name="rollingAverage">Specific period</param>
        /// <param name="format">Specific format csv/json</param>
        /// <returns>Result is full url</returns>
        public static Uri GetUriforChart(BaseApi.Type typechart, string namechart, Tuple<int, ArgChart.Date> timespan, Tuple<int, ArgChart.Date> rollingAverage, ArgChart.Formater format)
        {
            string args = $"{typechart}/{namechart}?";

            if (timespan != null)
            {
                args += $"&timespan={timespan.Item1}{timespan.Item2}";
            }

            if (rollingAverage != null)
            {
                args += $"&rollingAverage={rollingAverage.Item1}{rollingAverage.Item2}";
            }

            args += $"&format={format}";

            return new Uri(MainUriChart, args);
        }
    }
}
