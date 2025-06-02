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
using BitcoinWallet.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Droid_NativeDevice))]
namespace BitcoinWallet.Droid
{
    public class Droid_NativeDevice : IDevice
    {
        public ExtendedDevice Device
        {
            get { return ExtendedDevice.Android; }
        }
    }
}