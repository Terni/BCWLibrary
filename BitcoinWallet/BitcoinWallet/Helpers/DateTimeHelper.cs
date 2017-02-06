using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinMyWallet.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime DateTimeFromUnixTimestamp(this long value)
        {
            return new DateTime(1970, 1, 1).AddSeconds(value);
        }
    }
}
