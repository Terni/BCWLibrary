using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BitcoinWallet.Helpers
{
    public static class Tools
    {
        private static string _dynamicPath;

        static Tools()
        {
            _dynamicPath = CheckPlatform;
        }

        /// <summary>
        /// Property for Icon Folder
        /// </summary>
        public static string GetFolder
        {
            get { return $"Resources/{_dynamicPath}"; }
        }

        /// <summary>
        /// Property for CheckAll Platform
        /// </summary>
        private static string CheckPlatform
        {
            get
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    return "drawable/";
                }
                else if (Device.OS == TargetPlatform.Windows)
                {
                    return "Icons_menuItems/"; // for different platform
                }
                return string.Empty;
            }
        }
    }
}
