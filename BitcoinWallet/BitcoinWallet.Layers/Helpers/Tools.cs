using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Info.Blockchain.API.Wallet;
using Xamarin.Forms;

namespace BitcoinWallet.Layers.Helpers
{
    public static class Tools
    {
        private static string _droid;

        static Tools()
        {
            _droid = CheckPlatform;
        }

        /// <summary>
        /// Property for Icon Folder
        /// </summary>
        public static string GetFolder
        {
            get { return $"Resources/{_droid}Icons/"; }
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
                    return string.Empty; // for different platform
                }
                return string.Empty;
            }
        }
    }
}
