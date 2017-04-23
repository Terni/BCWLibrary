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
            {
                //await Navigation.PushModalAsync(VEmpty);
            }
                
        }

        private async void OnClickBack(object sender, EventArgs e)
        {
            if (Navigation != null)
            {
                int index = Navigation.ModalStack.Count - 2;
                if (index >= 0)
                {
                    Page p = Navigation.ModalStack[index];
                    await Navigation.PushModalAsync(p);
                }

                //await this.Navigation.PopAsync(); // go back
            }
        }
    }
}
