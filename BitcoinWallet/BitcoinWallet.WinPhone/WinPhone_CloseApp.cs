using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BitcoinWallet.Interface;
using BitcoinWallet.WinPhone;

[assembly: Dependency(typeof(WinPhone_CloseApp))]
namespace BitcoinWallet.WinPhone
{
    public class WinPhone_CloseApp : ICloseApp
    {
        public void CloseApp()
        {
            App.Current.Exit();
        }
    }
}