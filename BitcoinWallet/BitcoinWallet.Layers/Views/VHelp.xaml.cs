using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VHelp : TabbedPage
    {
        public VHelp()
        {
            InitializeComponent();
            ShowAllItems();
        }

        private async void ShowAllItems()
        {
            var scrollView = new ScrollView();
            var layout = new StackLayout();

            var label = new Label
            {

            };
            layout.Children.Add(label);

            var label2 = new Label
            {

            };
            layout.Children.Add(label2);

            // Show all labels
            scrollView.Content = layout;
            //this.HelpPage.Content = scrollView;
        }
    }
}
