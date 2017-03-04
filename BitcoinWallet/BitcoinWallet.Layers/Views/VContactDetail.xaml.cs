using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VContactDetail : TabbedPage
    {
        public VContactDetail()
        {
            InitializeComponent();
        }

        async void Detail_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VEmpty());
        }

    }
}
