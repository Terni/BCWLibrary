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

        private void BindableObject_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
            //TableSection tb = new TableSection();
            //TitleProperty
            //{ Setter
            //    new Setter();
            //}
            //tb.Title = Device.Styles.TitleStyle;
        }
    }
}
