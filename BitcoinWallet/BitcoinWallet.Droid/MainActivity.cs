using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Prism.Unity;
using Microsoft.Practices.Unity;
//using Telerik.XamarinForms.Common.Android;
//using Xamarin.Forms;
//using Xamarin.Forms.Platform.Android;

//// >> chart-getting-started-android-renderers
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Chart.RadCartesianChart), typeof(Telerik.XamarinForms.ChartRenderer.Android.CartesianChartRenderer))]
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Chart.RadPieChart), typeof(Telerik.XamarinForms.ChartRenderer.Android.PieChartRenderer))]
//// << chart-getting-started-android-renderers

//// >> calendar-getting-started-android-renderer
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadCalendar), typeof(Telerik.XamarinForms.InputRenderer.Android.CalendarRenderer))]
//// << calendar-getting-started-android-renderer

//// >> dataform-getting-started-android-renderer
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadDataForm), typeof(Telerik.XamarinForms.InputRenderer.Android.DataFormRenderer))]
//// << dataform-getting-started-android-renderer

//// >> listview-getting-started-android-renderer
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.DataControls.RadListView), typeof(Telerik.XamarinForms.DataControlsRenderer.Android.ListViewRenderer))]
//// << listview-getting-started-android-renderer

//// >> sidedrawer-getting-started-android-renderer
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Primitives.RadSideDrawer), typeof(Telerik.XamarinForms.PrimitivesRenderer.Android.SideDrawerRenderer))]
//// << sidedrawer-getting-started-android-renderer

//// >> autocomplete-getting-started-android-renderer
//[assembly: ExportRenderer(typeof(Telerik.XamarinForms.Input.RadAutoComplete), typeof(Telerik.XamarinForms.InputRenderer.Android.AutoCompleteRenderer))]
//// << autocomplete-getting-started-android-renderer
namespace BitcoinWallet.Droid
{
    [Activity(Label = "Bitcoin Wallet", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);     // init Xamarin.Forms
            global::Xamarin.FormsMaps.Init(this, bundle);       // init Xamarin.Forms.Maps
            //TelerikForms.Init(); // init Telerik

            LoadApplication(new App(new AndroidInitializer()));
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

