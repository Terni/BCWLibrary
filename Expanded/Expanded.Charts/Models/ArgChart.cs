using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanded.Charts.Models
{
    public class ArgChart
    {
        public enum Formater
        {
            json = 0,
            csv = 1
        }

        public enum Date
        {
            year = 0,
            years = 1,
            month = 2,
            months = 3,
            week = 4,
            weeks = 5,
            day = 6,
            days = 7,
            hour = 8,
            hours = 9,
            minute = 10,
            minutes = 11

        }

        public Tuple<int,Date> TimeSpan { get; set; }
        public Tuple<int, Date> RollingAverage { get; set; }
        public string Start { get; set; }
        public Formater Format { get; set; }
        public bool Sampled { get; set; }
    }
}
