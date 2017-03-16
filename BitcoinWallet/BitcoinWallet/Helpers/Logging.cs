using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Helpers
{
    public static class Logging
    {


        public static void Debug(string message, string tag = "")
        {
            System.Diagnostics.Debug.WriteLine("test........");

            //WriteMessage(message, LogType.typeDebug, tag);
            //Log.Debug(tag, message);
        }

    }
}
