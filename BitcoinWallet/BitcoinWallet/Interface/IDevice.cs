using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Models;

namespace BitcoinWallet.Interface
{
    public interface IDevice
    {
        ExtendedDevice Device { get; }
    }
}
