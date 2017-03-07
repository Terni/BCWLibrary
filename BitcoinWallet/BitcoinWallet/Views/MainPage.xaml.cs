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

            UserMP.Text = "";
            PassMP1.Text = "";
            PassMP2.Text = "";

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
