using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Interface;
using BitcoinWallet.Models;
using BitcoinWallet.UWP;

[assembly: Xamarin.Forms.Dependency(typeof(UWP_NativeDevice))]
namespace BitcoinWallet.UWP
{
    public class UWP_NativeDevice : IDevice
    {
        public ExtendedDevice Device
        {
            get
            {
                return ExtendedDevice.Windows10;
            }
        }
    }
}
