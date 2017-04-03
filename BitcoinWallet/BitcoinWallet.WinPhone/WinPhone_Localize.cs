using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BitcoinWallet.WinPhone;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(WinPhone_Localize))]
namespace BitcoinWallet.WinPhone
{
    public class WinPhone_Localize : ILocale
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo(
                Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }
    }
}
