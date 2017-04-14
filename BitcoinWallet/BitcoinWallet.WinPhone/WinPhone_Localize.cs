using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BitcoinWallet.WinPhone;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(WinPhone_Localize))]
namespace BitcoinWallet.WinPhone
{
    public class WinPhone_Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            CultureInfo culture =  new CultureInfo(Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());

            return culture;
        }

        public void SetLocalize(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }
    }
}
