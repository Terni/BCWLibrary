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
                IconSource = "contacts.png",
                TargetType = typeof(VContactDetail)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = "TodoList",
                IconSource = "todo2.png",
                TargetType = typeof(VContactDetail)
            });
            masterItems.Add(new MasterDetailItem
            {
                Title = "Reminders",
                IconSource = "reminders2.png",
                TargetType = typeof(VContactDetail)
            });

            listViewMasterItem.ItemsSource = masterItems;

        }
    }
}
