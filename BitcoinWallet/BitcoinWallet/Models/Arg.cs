using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Models
{
    public class Arg
    {
        public enum Formater
        {
            json = 0,
            csv = 1
        }

        public string BitcoinAddress { get; set; }

    }
}
