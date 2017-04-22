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
    public partial class VBook : TabbedPage
    {
        private Grid _tableGrid;

        public VBook()
        {
            InitializeComponent();

            ShowAllItemsFromDatabase();
        }

        /// <summary>
        /// Method for Show All items in Address Book from database
        /// </summary>
        private async void ShowAllItemsFromDatabase()
        {
            var scrollView = new ScrollView();
            var layout = new StackLayout();
            _tableGrid = new Grid();
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            List<ContactRow> contactList = new List<ContactRow>();
            { // TODO for testing
                ContactRow test = new ContactRow
                {
                    Alias = "Test",
                    Name = "Jon",
                    Surname = "Witch",
                    BitcoinAddress = "xdfgsff24fggfg45ghhfd1121ff"
                };
                contactList.Add(test);
            }

            //listItems = await GetListItemsDB(); // TODO dopsat
            for (int i = 0; i < contactList.Count; i++)
            {
                // init one contact and row for grid
                ContactRow contact = contactList[i];
                _tableGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                var frame = new Frame { OutlineColor = Color.Blue };
                var labelContact = new Label
                {
                    Text = $"{contact.Alias}, {contact.Name} {contact.Surname} \n{contact.BitcoinAddress}",
                    TextColor = Color.Blue,
                    FontSize = 10
                };
                frame.Content = labelContact;
                _tableGrid.Children.Add(frame, 0, i); // for colum 0 and row i

                //Button Text = "test" Grid.Row = "1" Grid.Column = "0" BackgroundColor = "#7ac3ff" HeightRequest = "100"
                var button = new Button
                {
                    Text = "",
                    BackgroundColor = Color.FromHex("7ac3ff"),
                };
                _tableGrid.Children.Add(button, 1, i); // for colum 0 and row i
            }

            // Show all labels
            scrollView.Content = _tableGrid;
            this.listBook.Content = scrollView;
        }
    }
}