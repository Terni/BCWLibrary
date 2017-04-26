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

            var hp1 = "Why am I not load my bitcoin address?" + Environment.NewLine +
                      "- You need to set http://blockchain.info to your account straight to your label Guid.\n\n";

            var hp2 = "Why is saved my Guid?" + Environment.NewLine +
                      "- Because it is too long.\n\n";

            var hp3 = "Why can not I load any value on my account?" + Environment.NewLine +
                      "- You probably have turned factoring Two autentization." +
                      " You must disable your account http://blockchain.info \n\n";

            var hp4 = "Why can not I send Bitcoin and when you send me an application wants the second password?" + Environment.NewLine +
                      "- The second password is obligated to send money. You have to set your" +
                      " account http://blockchain.info \n\n";

            var hp5 = "They are stored in my password to access my account?" + Environment.NewLine +
                      "- After starting the application are available only during runtime. We're not stored permanently.\n\n";

            var hp6 = "Why can not I start the application on Windows Phone 7 (7.1 or 7.5)?" + Environment.NewLine +
                      "- If this happened, please tell me. The application is primarily designed for the Windows Phone 8.1," +
                      " Universal Windows Platform and Android.\n\n";

            var hp7 = "Why am I not load any information and after you start HDD to your account 0 BTC?" + Environment.NewLine +
                      "- It is possible that you have a weak internet connection or often falls.\n\n";

            var hp8 = "Why am I not read history after payment to another account?" + Environment.NewLine +
                      "- Unfortunately, this problem is caused not confirmed transactions. Once at least one confirmed" +
                      " information will be loaded.\n\n\n";

            var hp9 = "Note: If you have any questions or find errors, please contact me. Email is \"about\".";


            var label = new Label
            {
                TextColor = Color.Black,
                Text = hp1+hp2+hp3+hp4+hp5+hp6+hp7+hp8+hp9,
                FontSize = 16
            };
            layout.Children.Add(label);

            //var label2 = new Label
            //{

            //};
            //layout.Children.Add(label2);

            // Show all labels
            scrollView.Content = layout;
            this.HelpPage.Content = scrollView;
        }
    }
}
