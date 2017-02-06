using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class NewFeeHelper
    {

        public static Boolean GetNewTxFee(string jsonData)
        {
            var jresult = JObject.Parse(jsonData).Property("result").Value.AsEnumerable();
            var jvalue = jresult.Value<bool>();

            return jvalue;
        }
    }
}
