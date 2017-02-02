using System.ComponentModel;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        //private void BindableObject_OnPropertyChangedopertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //     this.BarTextColor = Color.Red;
        //}

        private void BindableObject_OnPropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            if (e != null)
            {
                this.BarTextColor = Color.Gray;
            }
            else
            {
                this.BarTextColor = Color.Black;
            }
        }
    }
}
