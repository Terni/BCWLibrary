using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using BitcoinWallet.UWP;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(UWP_Localize))]
namespace BitcoinWallet.UWP
{
    public class UWP_Localize : ILocale
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
