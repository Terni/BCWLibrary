using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.ViewModels;
using Xamarin.Forms;
using BitcoinWallet.Helpers;
using BitcoinWallet.Interface;

namespace BitcoinWallet.Views
{
    public partial class VMenuItems : MasterDetailPage
    {
        public VMenuItems()
        {
            InitializeComponent();
            masterDetail.ListView.ItemSelected += OnItemSelected;
            //var test = Device.OS;

            //Master.Title = "Fast Menu";
            Master.Icon = $"{Tools.GetFolder}gotoslide.png";

            //ToolbarItem itm = new ToolbarItem();
            //itm.Name = "Fast Menu";
            //itm.Icon = "swap.png";
            //Master.ToolbarItems.Add(itm);
            ToolbarItem itmBarPay = new ToolbarItem
            {
                Name = "Payment",
                Icon = $"{Tools.GetFolder}send.money.png",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            itmBarPay.Clicked += OnClickPayButton;
            Master.ToolbarItems.Add(itmBarPay);

            ToolbarItem itmBarLogoff = new ToolbarItem
            {
                Name = "Log off",
                Icon = $"{Tools.GetFolder}logoff.png",
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            itmBarLogoff.Clicked += OnClickLogoffButton;
            Master.ToolbarItems.Add(itmBarLogoff);

            ToolbarItem itmBarAbout = new ToolbarItem
            {
                Text = "about",
                Order = ToolbarItemOrder.Secondary,
                Priority = 1
            };
            itmBarAbout.Clicked += OnClickAboutButton;
            Master.ToolbarItems.Add(itmBarAbout);

        }

        private async void OnClickAboutButton(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VAbout());
        }

        private void OnClickLogoffButton(object sender, EventArgs e)
        {
            var closer = DependencyService.Get<ICloseApp>();
            if (closer != null)
                closer.CloseApp();
        }

        private async void OnClickPayButton(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VPayment());
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterDetailItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterDetail.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
