using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Layers.Models
{
    public enum TypeTrans
    {
        Recieve = 0,
        Send = 1
    }

    public class TransRow
    {
        public string BitcoinAddress { get; set; }
        public long Value { get; set; }
        public TypeTrans Type { get; set; }
        public DateTime Date { get; set; }
    }
}
