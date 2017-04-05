using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using BitcoinWallet.Interface;

namespace BitcoinWallet.ViewModels
{
    public class Loc
    {
        const string ResourceId = "BitcoinWallet.Resx.Resources";

        public static void SetLocalize(CultureInfo ci)
        {
            DependencyService.Get<ILocalize>().SetLocalize(ci);
        }

        /// <remarks>
        /// Maybe we can cache this info rather than querying every time
        /// </remarks>
        [Obsolete]
        public static string GetLocalize()
        {
            return DependencyService.Get<ILocalize>().GetCurrentCultureInfo().ToString();
        }

        /// <summary>
        /// Method for Localizace with default Localize
        /// </summary>
        /// <param name="key">Specific key for lozalize</param>
        /// <param name="defaultLocalize">default value</param>
        /// <returns></returns>
        public static string Localize(string key, string defaultLocalize)
        {
            //var netLanguage = GetLocalize();

            // Platform-specific
            ResourceManager temp = new ResourceManager(ResourceId, typeof(Loc).GetTypeInfo().Assembly);
            Debug.WriteLine("Localize " + key);
            string result = temp.GetString(key, DependencyService.Get<ILocalize>().GetCurrentCultureInfo());

            if(string.IsNullOrWhiteSpace(result)) // is null
            {
                if (!string.IsNullOrEmpty(defaultLocalize))
                {
                    return defaultLocalize; //set default localize
                }
                else
                {
                    return key; // HACK: return the key, which GETS displayed to the user
                }
            }

            return result;
        }

    }
}
