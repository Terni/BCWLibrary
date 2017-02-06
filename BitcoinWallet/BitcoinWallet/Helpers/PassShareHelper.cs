using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class PassShareHelper
    {
        public static Boolean GetResult(string jsonData)
        {
            var jresult = JObject.Parse(jsonData).Property("result").Value.AsEnumerable();
            var jvalue = jresult.Value<bool>();

            //if (jvalue == true)
            //{
            //    return true;
            //}

            return jvalue;
        }

    }
}
