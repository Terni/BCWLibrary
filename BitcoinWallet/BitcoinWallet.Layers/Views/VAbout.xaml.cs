using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BitcoinWallet.Views
{
    public partial class VAbout : ContentPage
    {
        private string _donateBitcoinAddress = "1ExSUAx9yjXqbMGzM8bAuSU3yHbR8SQyd4";

        public VAbout()
        {
            InitializeComponent();
            ShowAllItems();
        }

        private async void ShowAllItems()
        {
            var scrollView = new ScrollView();
            var layout = new StackLayout
            {
                //Margin = new Thickness(10, 10, 10, 0),
                Spacing = 20,
                Padding = 20,
                VerticalOptions = LayoutOptions.Center
            };

            var info = "Wallets works based on the created account on the website http://blockchain.info. Does not impose any" +
                       " additional passwords for running only for a single execution. It is intended for all who welcome new things" +
                       " to facilitate daily life.\n\n";

            var donate = "If you like the app please help in the development of new features that consume time and money." +
                         " Please click the button below and donate the amount of Bitcoin." +
                         " Your help would be appreciated. Thank you.\n\n";

            var report = "Finally, please contact me if you find bugs and strange behavior. Carefully describe the problem" +
                         " with a photo or video recording problem. They also welcome suggestions for improvement with a detailed" +
                         " description or extension for the status quo.\n\n\n";

            string emailAddress = "bitcoinmywallet@hotmail.com\n\n\n";

            var note = "Note: Operation is based on your decision. I do not take any responsibility" +
                       " if someone smart drives theft or any other problems!\n\n";


            var label = new Label
            {
                TextColor = Color.Black,
                Text = info+donate+report+emailAddress+note,
                FontSize = 16
            };
            layout.Children.Add(label);

            var button = new Button
            {
                Text = "Donate",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("7ac3ff"),
                HeightRequest = 40,
                BorderRadius = 20,
                Margin = new Thickness(0,0,0,10),
                BorderWidth = 3,
                BorderColor = Color.FromHex("7ac3ff"),
                AutomationId = _donateBitcoinAddress
            };
            button.Clicked  += OnClickButtonSetBitAddress;
            layout.Children.Add(button);

            //< !--Colors-- >
            //< Color x: Key = "LightBlue" >#7ac3ff</Color>
            //< Color x: Key = "DarkBlue" >#3181c4</Color>
            //< Color x: Key = "White" > White </ Color >
            //< Color x: Key = "Black" > Black </ Color >
            //< Color x: Key = "Red" > Red </ Color >
            //< Color x: Key = "LightRed" >#ff5151</Color>

            //< !--Button style-- >
            //< Style x: Key = "ClassicButtonStyle" TargetType = "Button" >
            //< Setter Property = "BackgroundColor" Value = "{StaticResource LightBlue}" ></ Setter >
            //< Setter Property = "HeightRequest" Value = "40" ></ Setter >
            //< Setter Property = "TextColor" Value = "{StaticResource White}" ></ Setter >
            //< Setter Property = "BorderRadius" Value = "20" ></ Setter >
            //< Setter Property = "Margin" Value = "0,0,0,10" ></ Setter >
            //< Setter Property = "BorderWidth" Value = "3" ></ Setter >
            //< Setter Property = "BorderColor" Value = "{StaticResource LightBlue}" ></ Setter >
            //</ Style >


            // Show all labels
            scrollView.Content = layout;
            this.Content = scrollView;
        }

        /// <summary>
        /// Method for add address to ViewPayment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnClickButtonSetBitAddress(object sender, EventArgs e)
        {
            VPayment.BitcoinAddressFromBook = (sender as Button)?.AutomationId;

            if (Navigation != null)
                await Navigation.PushModalAsync(new VPayment());
        }

    }
}
