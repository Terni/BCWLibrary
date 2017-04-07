using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.ViewModels;
using Xamarin.Forms;
using BitcoinWallet.Helpers;

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
                Title = " Contacts",
                IconSource = $"{Tools.GetFolder}contacts.dark.png",
                TargetType = typeof(VContactDetail)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " Address Book",
                IconSource = $"{Tools.GetFolder}todo.dark.png",
                TargetType = typeof(VBook)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = " About",
                IconSource = $"{Tools.GetFolder}reminders.dark.png",
                TargetType = typeof(VAbout)
            });

            listViewMasterItem.ItemsSource = masterItems;
        }
    }
}
