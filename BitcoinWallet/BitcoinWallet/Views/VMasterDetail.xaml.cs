using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.ViewModels;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VMasterDetail : ContentPage
    {
        public ListView ListView { get { return listViewMasterItem; } }

        public VMasterDetail()
        {
            InitializeComponent();

            string droid = "";
            if (Device.OS == TargetPlatform.Android)
            {
                droid = "drawable/";
            }
            var masterItems = new List<MasterDetailItem>();
            masterItems.Add(new MasterDetailItem
            {
                Title = " Contacts",
                IconSource = "Resources/" + droid + "Icons_menuItems/contacts.dark.png",
                TargetType = typeof(VContactDetail)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " Address Book",
                IconSource = "Resources/" + droid + "Icons_menuItems/todo.dark.png",
                TargetType = typeof(VBook)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " About",
                IconSource = "Resources/" + droid + "Icons_menuItems/reminders.dark.png",
                TargetType = typeof(VAbout)
            });

            listViewMasterItem.ItemsSource = masterItems;

        }
    }
}
