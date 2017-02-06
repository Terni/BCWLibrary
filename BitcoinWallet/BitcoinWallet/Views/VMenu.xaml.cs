using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VMenu : TabbedPage
    {
        private float _defaultBTC;



        public VMenu()
        {
            //Init variables
            _defaultBTC = 0;



            InitializeComponent();
            ValueBw.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            ValueBw.Text = _defaultBTC +" BTC";
        }

        async void Test_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VKeyboard());
        }
        async void Payment_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VPayment());
        }
        async void Book_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VBook());
        }
        async void History_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VHistory());
        }
        async void Charts_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VCharts());
        }
    }
}
