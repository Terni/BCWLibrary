using Prism.Unity;
using BitcoinWallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml.Internals;
using Xamarin.Forms.Maps;

namespace BitcoinWallet
{

    public partial class App : PrismApplication
    {

        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
