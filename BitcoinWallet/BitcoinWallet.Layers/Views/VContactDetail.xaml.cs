using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Layers.Models;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VContactDetail : TabbedPage
    {
        public VContactDetail()
        {
            InitializeComponent();

            FillValueToEntryCell();

        }


        private async void FillValueToEntryCell()
        {
            if (!string.IsNullOrWhiteSpace(ApiLogon.FromMyBitcoinAddress))
            {
                xadress.Text = ApiLogon.FromMyBitcoinAddress;
            }
            else
            {
                try
                {
                    //For From Address
                    ApiLogon.AddressList = await ApiLogon.Wallet.ListAddressesAsync();
                    foreach (var adr in ApiLogon.AddressList)
                    {
                        ApiLogon.Address = adr;
                        ApiLogon.FromMyBitcoinAddress = adr.AddressStr;
                        break;
                    }
                    SetFromBitcoinAddress(); //TODO: HACK for testing

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error from server or client! Error is: {ex}");
                    //Logging.Debug($"Error from server or client! Error is: {ex}");

                    SetFromBitcoinAddress(); //TODO: HACK for testing
                }
            }

        }

        private void SetFromBitcoinAddress()
        {
            if (string.IsNullOrWhiteSpace(ApiLogon.FromMyBitcoinAddress))
            {
                ApiLogon.FromMyBitcoinAddress = Bitcoin.APIv2Client.Models.DataLogon.AddressWallet;
                xadress.Text = ApiLogon.FromMyBitcoinAddress;
            }
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
