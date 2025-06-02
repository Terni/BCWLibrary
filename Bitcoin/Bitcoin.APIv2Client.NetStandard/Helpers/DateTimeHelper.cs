using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.NetStandard.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Method for convert UnixTimeStamp to DateTime
        /// </summary>
        /// <param name="value">specific data long</param>
        /// <returns>Result is specific DateTime</returns>
        public static DateTime ConvertFromUnixTimeStamp(this long value) {
            return new DateTime(1970, 1, 1).AddSeconds(value);
        }
    }
}
