using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VPayment : TabbedPage
    {
        public static string BitcoinAddressFromBook { get; set; }

        public VPayment()
        {
            InitializeComponent();

            //Set adress
            if (!string.IsNullOrWhiteSpace(BitcoinAddressFromBook))
            {
                ValueAddress.Text = BitcoinAddressFromBook;
                ValueAddress2.Text = BitcoinAddressFromBook;
            }
        }

        private async void Add_OnClicked(object sender, EventArgs e)
        {
            VBook.IsAddAddress = true;
            if (Navigation != null)
                await Navigation.PushModalAsync(new VBook());
        }
    }
}
