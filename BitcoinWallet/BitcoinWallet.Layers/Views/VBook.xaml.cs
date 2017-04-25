using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Layers.Helpers;
using BitcoinWallet.Layers.Models;
using Xamarin.Forms;
using Expanded.Common;
using Expanded.DBase.ViewModels;
using XLabs.Enums;
using XLabs.Forms.Controls;
using Expanded.DBase.Models;
using Expanded.DBase.ViewModels;

namespace BitcoinWallet.Views
{
    public partial class VBook : TabbedPage
    {
        private Grid _tableGrid;

        public static bool IsAddAddress { get; set; }
        public static ItemsDatabase Database { get; set; }

        private bool TestItem;

        public VBook()
        {
            InitializeComponent();

            ShowAllItemsFromDatabase();
            TestItem = true;
        }

        /// <summary>
        /// Method for Show All items in Address Book from database
        /// </summary>
        private async void ShowAllItemsFromDatabase()
        {
            var scrollView = new ScrollView();
            _tableGrid = new Grid();
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            _tableGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            List<ContactItem> contactList = new List<ContactItem>();

            { 
                if (!TestItem) // TODO for testing
                    TestAddFistItemsToDatabase();
            }

            contactList = Database.PropertyContactSpec.GetItemsAll(); //Get all imtes form database

            for (int i = 0; i < contactList.Count; i++)
            {
                // init one contact and row for grid
                ContactItem contact = contactList[i];
                _tableGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

                var frame = new Frame
                {
                    OutlineColor = Color.Blue,
                    Margin = new Thickness(0), // left, Top, Right, Botton
                    Padding = new Thickness(-5)
                };
                var bntContact = new Button
                {
                    Text = $"{contact.Alias}, {contact.FirstName} {contact.LastName} \n{contact.Address}",
                    TextColor = Color.Blue,
                    AutomationId = contact.Address,
                    FontSize = 10,
                };
                bntContact.Clicked += OnClickButtonSetBitAddress;
                frame.Content = bntContact;
                
                _tableGrid.Children.Add(frame, 0, i); // for colum 0 and row i

                //Button Text = "test" Grid.Row = "1" Grid.Column = "0" BackgroundColor = "#7ac3ff" HeightRequest = "100"
                //var button = new Button
                //{
                //    Text = "",
                //    BackgroundColor = Color.FromHex("7ac3ff"),
                //};
                //_tableGrid.Children.Add(button, 1, i); // for colum 0 and row i

                ImageButton remBtn = new ImageButton
                {
                    IsVisible = true,
                    ImageHeightRequest = 30,
                    ImageWidthRequest = 30,
                    Orientation = ImageOrientation.ImageCentered,
                    Image = "Resources/Icons/delete.png",
                    TextColor = Color.FromHex("000000"),
                    Text = "",
                    AutomationId = contact.Address
                };
                remBtn.Clicked += OnClickButtonRemove;
                remBtn.Source = FileImageSource.FromFile($"{Tools.GetFolder}delete.png");
                _tableGrid.Children.Add(remBtn, 1, i); // for colum 0 and row i
            }

            // Show all labels
            scrollView.Content = _tableGrid;
            this.listBook.Content = scrollView;
        }

        /// <summary>
        /// Method for add address to ViewPayment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnClickButtonSetBitAddress(object sender, EventArgs e)
        {
            if (IsAddAddress)
            {
                VPayment.BitcoinAddressFromBook = (sender as Button)?.AutomationId;
                IsAddAddress = false; // reset status

                if (Navigation != null)
                    await Navigation.PushModalAsync(new VPayment());
            }
        }

        /// <summary>
        /// Method for delete one contact item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickButtonRemove(object sender, EventArgs e)
        {
            var address = (sender as Button).AutomationId;
            Debug.WriteLine($"Delete address: {address}");

            Database.PropertyContactSpec.DeleteAsAddress(address);

            ShowAllItemsFromDatabase(); // update contentpage
        }

        /// <summary>
        /// Method for add new contact item and update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickAddNewContact(object sender, EventArgs e)
        {
            var contact = new ContactItem
            {
                Id = Database.PropertyContactSpec.GenerLastIndex(),
                FirstName = xname.Text,
                LastName = xsurname.Text,
                Alias = xalias.Text,
                Address = xaddress.Text,
                Date = DateTime.Now.ToString()
            };

            Database.PropertyContactSpec.SaveItem(contact);

            ShowAllItemsFromDatabase(); // update contentpage
        }

        private void TestAddFistItemsToDatabase()
        {
            var testContact = new ContactItem
            {
                Id = Database.PropertyContactSpec.GenerLastIndex(),
                Alias = "Test",
                FirstName = "Jon",
                LastName = "Witch",
                Address = "xdfgsff24fggfg45ghhfd1121ff",
                Date = DateTime.Now.ToString()
            };

            Database.PropertyContactSpec.SaveItem(testContact);
        }
    }
}