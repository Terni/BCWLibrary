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

            if (Device.OS == TargetPlatform.Windows)
            {
                Master.Icon = "swap.png";

                ToolbarItem itm = new ToolbarItem();
                itm.Name = "something";
                itm.Icon = "swap.png";
                Master.ToolbarItems.Add(itm);

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Name = "Swap 2",
                    Icon = "reminders.png",
                    Order = ToolbarItemOrder.Primary,
                    Priority = 0
                });

                Master.ToolbarItems.Add(new ToolbarItem
                {
                    Text = "about",
                    Order = ToolbarItemOrder.Secondary,
                    Priority = 1
                    //Icon = "reminders.png"
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
