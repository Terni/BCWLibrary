using Prism.Unity;
using BitcoinWallet.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml.Internals;
using Expanded.DBase.ViewModels;
using BitcoinWallet.Interface;
using BitcoinWallet.Helpers;
//using Xamarin.Forms.Maps;

namespace BitcoinWallet
{

    public partial class App : PrismApplication
    {
        static ItemsDatabase _database;

        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
            Logging.ReleaseTag = false;
            Logging.Debug("Start app.",4);
        }

        public static ItemsDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new ItemsDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Database\\LogDB.db3"));
                }
                return _database;
            }

        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainPage", animated: false);
            //Database.PropertyLog.SaveItemAsync
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
        }
    }
}
