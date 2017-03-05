using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            // TODO: ciste pro testovani !! Musi se zmazat !!
            UserMP.Text = "1393dcec-2f1d-45f3-8055-a304636dce13";
            PassMP1.Text = "ro1008UKOMO87";
            PassMP2.Text = "ro1008UKOMO1987";

        }



        //private void BindableObject_OnPropertyChangedopertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //     this.BarTextColor = Color.Red;
        //}

        private void BindableObject_OnPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e.PropertyName == "CPprofile")
            {
                this.BarTextColor = Color.Gray;
            }
            else if (e.PropertyName == "CPsetting")
            {
                this.BarTextColor = Color.Black;
            }
        }

        async void Loging_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VMenuItems());
            //Navigation.PushAsync(new menuPage());
        }
    }
}
