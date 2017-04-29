using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.ViewModels;
using Xamarin.Forms;
using BitcoinWallet.Helpers;
using BitcoinWallet.Layers.Views;

namespace BitcoinWallet.Views
{
    public partial class VMasterDetail : ContentPage
    {
        /// <summary>
        /// Property for ListView
        /// </summary>
        public ListView ListView
        {
            get { return listViewMasterItem; }
        }

        public VMasterDetail()
        {
            InitializeComponent();

            var masterItems = new List<MasterDetailItem>();
            masterItems.Add(new MasterDetailItem
            {
                Title = " Profil",
                IconSource = $"{Tools.GetFolder}contacts_dark.png",
                TargetType = typeof(VContactDetail)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " Address Book",
                IconSource = $"{Tools.GetFolder}todo_dark.png",
                TargetType = typeof(VBook)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " Transaction",
                IconSource = $"{Tools.GetFolder}trans_dark.png",
                TargetType = typeof(VHistory)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " Charts",
                IconSource = $"{Tools.GetFolder}charts_dark.png",
                TargetType = typeof(Expanded.Charts.Views.VCharts)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " ATM & Shops",
                IconSource = $"{Tools.GetFolder}shops_dark.png",
                TargetType = typeof(VShops)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " About",
                IconSource = $"{Tools.GetFolder}reminders_dark.png",
                TargetType = typeof(VAbout)
            });

            listViewMasterItem.ItemsSource = masterItems;
        }
    }
}
