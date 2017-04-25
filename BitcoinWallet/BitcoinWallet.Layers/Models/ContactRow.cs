using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinWallet.Layers.Models
{
    public class ContactRow
    {
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BitcoinAddress { get; set; }
    }
}
