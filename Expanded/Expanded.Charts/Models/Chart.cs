using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanded.Charts.Models
{
    public class Chart
    {
        public string TimeSpan { get; set; }
        public string RollingAverage { get; set; }
        public string Start { get; set; }
        public string Format { get; set; }
        public bool sampled { get; set; }
    }
}
