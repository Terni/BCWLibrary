using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;
using Android.App;
using Android.Content;
//using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BitcoinWallet.Interface;

[assembly: Dependency(typeof(BitcoinWallet.Droid.Droid_FileHelper))]
namespace BitcoinWallet.Droid
{
    public class Droid_FileHelper : IFileHelper
    {

        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}