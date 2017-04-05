using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.ViewModels;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VMenuItems : MasterDetailPage
    {
        public VMenuItems()
        {
            InitializeComponent();
            masterDetail.ListView.ItemSelected += OnItemSelected;
            //var test = Device.OS;

            if (Device.OS == TargetPlatform.Windows)
            {
                //Master.Title = "Fast Menu";
                Master.Icon = "Resources/Icons_menuItems/gotoslide.png";

                //ToolbarItem itm = new ToolbarItem();
                //itm.Name = "Fast Menu";
                //itm.Icon = "swap.png";
                //Master.ToolbarItems.Add(itm);

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Name = "Payment",
                    Icon = "Resources/Icons_menuItems/send.money.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                });

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Name = "Log off",
                    Icon = "Resources/Icons_menuItems/logoff.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                });

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Text = "about",
                    Order = ToolbarItemOrder.Secondary,
                    Priority = 1
                });
            }

            if (Device.OS == TargetPlatform.Android)
            {
                //Master.Title = "Fast Menu";
                Master.Icon = "Resources/drawable/Icons_menuItems/gotoslide.png";

                //ToolbarItem itm = new ToolbarItem();
                //itm.Name = "Fast Menu";
                //itm.Icon = "swap.png";
                //Master.ToolbarItems.Add(itm);

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Name = "Payment",
                    Icon = "Resources/drawable/Icons_menuItems/send.money.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                });

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Name = "Log off",
                    Icon = "Resources/drawable/Icons_menuItems/logoff.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                });

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Text = "about",
                    Order = ToolbarItemOrder.Secondary,
                    Priority = 1
                });
            }

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
