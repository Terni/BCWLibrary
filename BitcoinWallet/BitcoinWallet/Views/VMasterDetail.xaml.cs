using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.ViewModels;
using Xamarin.Forms;
using BitcoinWallet.Helpers;
using BitcoinWallet.Interface;
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
                Title = " Payment",
                IconSource = $"{Tools.GetFolder}payment_dark.png",
                TargetType = typeof(VPayment)
            });

            masterItems.Add(new MasterDetailItem
            {
                Title = " Address Book",
                IconSource = $"{Tools.GetFolder}group_dark.png",
                TargetType = typeof(VBook)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " History",
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
            //masterItems.Add(new MasterDetailItem
            //{
            //    Title = " Help",
            //    IconSource = $"{Tools.GetFolder}help_dark.png",
            //    TargetType = typeof(VHelp)
            //});
            masterItems.Add(new MasterDetailItem
            {
                Title = " About",
                IconSource = $"{Tools.GetFolder}about_dark.png",
                TargetType = typeof(VAbout)
            });
            //var logoff = new MasterDetailItem
            //{
            //    Title = " Log off",
            //    IconSource = $"{Tools.GetFolder}logoff_dark.png"
            //};
            //var closer = DependencyService.Get<ICloseApp>();
            //if (closer != null)
            //    logoff.TargetType = typeof(closer.CloseApp(););
            //masterItems.Add(logoff);

           listViewMasterItem.ItemsSource = masterItems;
        }

        //private void OnClickLogoffButton(object sender, EventArgs e)
        //{
        //    var closer = DependencyService.Get<ICloseApp>();
        //    if (closer != null)
        //        closer.CloseApp();
        //}
    }
}



//ToolbarItem itmBarLogoff = new ToolbarItem
//{
//Name = "Log off",
//Icon = $"{Tools.GetFolder}logoff.png",
//Order = ToolbarItemOrder.Primary,
//Priority = 0
//};
//itmBarLogoff.Clicked += OnClickLogoffButton;
//Master.ToolbarItems.Add(itmBarLogoff);