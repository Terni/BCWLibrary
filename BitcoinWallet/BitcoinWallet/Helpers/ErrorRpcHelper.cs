using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BitcoinMyWallet.Helpers
{
    public class ErrorRpcHelper
    {
        public static String GetError(string jsonData)
        {
            var jresult = JObject.Parse(jsonData).Property("error").Value.AsEnumerable();
            //var jvalue = jresult.Value<string>();
            var stringValue = jresult.ToString();
            String jvalue = null;

            if (stringValue.IndexOf("-32603") != -1)
            {
                return "Internal error on Rpc Server! You have unconfirmation Transaction!";
            }
            else
            {
                jvalue = jresult.Value<string>();
            }

            return jvalue;
        }

    }
}
