using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BitcoinWallet.Droid;
using BitcoinWallet.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(Droid_CloseApp))]
namespace BitcoinWallet.Droid
{
    public class Droid_CloseApp : ICloseApp
    {
        public void CloseApp()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}