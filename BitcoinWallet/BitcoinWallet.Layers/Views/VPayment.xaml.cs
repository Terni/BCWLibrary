using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Layers.Models;
using BitcoinWallet.Layers.Helpers;
using Info.Blockchain.API.BlockExplorer;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class VPayment : TabbedPage
    {
        public static string BitcoinAddressFromBook { get; set; }

        public VPayment()
        {
            InitializeComponent();

            // Init cell for Balance
            float myBalance =  (float) ApiLogon.Balance.Btc / BitcoinValue.SatoshisPerBitcoin;
            mb.Text = mb2.Text = myBalance.ToString();

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

        private async void OnClickSend(object sender, EventArgs e)
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
                if (string.IsNullOrWhiteSpace(ApiLogon.FromMyBitcoinAddress)) //TODO: HACK for testing
                    ApiLogon.FromMyBitcoinAddress = Bitcoin.APIv2Client.Models.DataLogon.AddressWallet;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error from server or client! Error is: {ex}");
                //Logging.Debug($"Error from server or client! Error is: {ex}");
            }

            //For To Address
            if (!string.IsNullOrWhiteSpace(ValueAddress.Text))
                ApiLogon.ToBitcoinAddress = ValueAddress.Text;
            else
            {
                ApiLogon.ToBitcoinAddress = ValueAddress2.Text;
            }

            //For Amount
            if (!string.IsNullOrWhiteSpace(vtp.Text))
                ApiLogon.MyAmount = Convert.ToDouble(vtp.Text);
            else
            {
                ApiLogon.MyAmount = Convert.ToDouble(vtp2.Text);
            }
            BitcoinValue amount = new BitcoinValue((decimal)ApiLogon.MyAmount * BitcoinValue.SatoshisPerBitcoin);

            if (ApiLogon.MyAmount < 0 || string.IsNullOrWhiteSpace(ApiLogon.ToBitcoinAddress)) // TODO correct is ApiLogon.MyAmount <= 0
            {
                await DisplayAlert("Warning",$"Amount or To Address are bad filled!", "OK");
            }
            else if (ApiLogon.MyAmount > (float) ApiLogon.Balance.Btc / BitcoinValue.SatoshisPerBitcoin)
            {
                await DisplayAlert("Warning", $"Amount higher than Balance!", "OK");
            }
            else
            {
                //For Test Yes or No send money
                bool result = await OnAlertYesNoClicked(sender, e);
                if (result)
                {
                    try
                    {
                        //For SendMoney, (toAddres, Amount, fromAddress, fee=0.0001, note)
                        ApiLogon.PayResponse =
                            await ApiLogon.Wallet.SendAsync(ApiLogon.ToBitcoinAddress, amount,
                                ApiLogon.FromMyBitcoinAddress, new BitcoinValue(10000), null);

                        await DisplayAlert("Successfully",
                            $"Send amount is: {ApiLogon.MyAmount}\n to {ApiLogon.ToBitcoinAddress}\n" +
                            $" trans. hash is {ApiLogon.PayResponse.TxHash}\n message is {ApiLogon.PayResponse.Message}", "OK");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Error from server or client! Error is: {ex}");
                        //Logging.Debug($"Error from server or client! Error is: {ex}");

                        await DisplayAlert("Successfully",
                            $"Send amount is: {ApiLogon.MyAmount}\n to {ApiLogon.ToBitcoinAddress}", "OK"); //TODO HACK for testing
                    }
                }
            }
        }

        async Task<bool> OnAlertYesNoClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Do you really want to send bitcoins?", $"Amount is: {ApiLogon.MyAmount} and Fee is: 0.0001", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
            return answer;
        }
    }
}
