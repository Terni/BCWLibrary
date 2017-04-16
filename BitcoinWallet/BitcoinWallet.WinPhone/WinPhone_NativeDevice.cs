using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Interface;
using BitcoinWallet.Models;
using BitcoinWallet.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhone_NativeDevice))]
namespace BitcoinWallet.WinPhone
{
    public class WinPhone_NativeDevice : IDevice
    {
        public ExtendedDevice Device
        {
            get
            {
                return ExtendedDevice.WinPhone81;
            }
        }
    }
}
