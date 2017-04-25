using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BitcoinWallet.Interface;
using BitcoinWallet.UWP;

[assembly: Dependency(typeof(UWP_CloseApp))]
namespace BitcoinWallet.UWP
{
    public class UWP_CloseApp : ICloseApp
    {
        public void CloseApp()
        {
            App.Current.Exit();
        }
    }
}
