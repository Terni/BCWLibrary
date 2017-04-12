using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.Models
{
    public class DataPointChart
    {
        /// <summary>
        /// Properties
        /// </summary>
        public DateTime Date { get; set; }
        public float Value { get; set; }

    }
}
