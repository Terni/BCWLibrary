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

            var masterItems = new List<MasterDetailItem>();
            masterItems.Add(new MasterDetailItem
            {
                Title = "Contacts",
                IconSource = "Resources/Icons_menuItems/contacts2.png",
                TargetType = typeof(VContactDetail)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = "Address Book",
                IconSource = "Resources/Icons_menuItems/todo2.png",
                TargetType = typeof(VBook)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = "About",
                IconSource = "Resources/Icons_menuItems/reminders2.png",
                TargetType = typeof(VAbout)
            });

            listViewMasterItem.ItemsSource = masterItems;

        }
    }
}
