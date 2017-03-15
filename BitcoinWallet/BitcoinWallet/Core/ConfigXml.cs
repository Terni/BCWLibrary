using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Core
{
    public class Modules
    {
        private string _strValue;
        private bool _visible;
        private bool _enable;
        private bool _secure;


        public string Name { get; set; }

        public string Value
        {
            get
            {
                if (_strValue == null)
                {
                    return string.Empty;
                }
                return _strValue;
            }
            set { _strValue = value; }
        }
        public bool? Visible { get; set; }
        public bool? Enable { get; set; }
        public bool? Secure { get; set; }
    }

    public class Wallet
    {
        public int Number { get; set; }
    }
}
