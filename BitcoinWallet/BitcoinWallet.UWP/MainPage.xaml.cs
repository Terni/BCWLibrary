using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prism.Unity;
using Microsoft.Practices.Unity;
using Telerik.XamarinForms.Common.UWP;
using BitcoinWallet.Helpers;


// >> chart-getting-started-uwp-renderers
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.Chart.RadCartesianChart), typeof(Telerik.XamarinForms.ChartRenderer.UWP.CartesianChartRenderer))]
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.Chart.RadPieChart), typeof(Telerik.XamarinForms.ChartRenderer.UWP.PieChartRenderer))]
// << chart-getting-started-uwp-renderers

// >> calendar-getting-started-uwp-renderer
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.Input.RadCalendar), typeof(Telerik.XamarinForms.InputRenderer.UWP.CalendarRenderer))]
// << calendar-getting-started-uwp-renderer

// >> sidedrawer-getting-started-uwp-renderer
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.Primitives.RadSideDrawer), typeof(Telerik.XamarinForms.PrimitivesRenderer.UWP.SideDrawerRenderer))]
// << sidedrawer-getting-started-uwp-renderer

// >> listview-getting-started-uwp-renderer
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.DataControls.RadListView), typeof(Telerik.XamarinForms.DataControlsRenderer.UWP.ListViewRenderer))]
// << listview-getting-started-uwp-renderer

// >> dataform-getting-started-uwp-renderer
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.Input.RadDataForm), typeof(Telerik.XamarinForms.InputRenderer.UWP.DataFormRenderer))]
// << dataform-getting-started-uwp-renderer

// >> autocomplete-getting-started-uwp-renderer
[assembly: Xamarin.Forms.Platform.UWP.ExportRenderer(typeof(Telerik.XamarinForms.Input.RadAutoComplete), typeof(Telerik.XamarinForms.InputRenderer.UWP.AutoCompleteRenderer))]
// << autocomplete-getting-started-uwp-renderer

namespace BitcoinWallet.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("5A9AFGEvcl6PpV4TY8sG~QvPMPT_IBFiwtOmBuo42dQ~AhWtvUiUv1j4tqrPmIA4ukPOSnzD83adgtBZaWuzQwrcD1WobBrpYp - OC7q6wZ_w");
            LoadApplication(new BitcoinWallet.App(new UwpInitializer()));
            TelerikForms.Init();
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}
