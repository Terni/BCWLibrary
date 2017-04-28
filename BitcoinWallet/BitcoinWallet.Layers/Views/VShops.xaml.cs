using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitcoin.APIv2Client.Models;
using BitcoinWallet.Layers.ViewModels;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms;

namespace BitcoinWallet.Layers.Views
{
    public partial class VShops : TabbedPage
    {
        /// <summary>
        /// Variables
        /// </summary>
        private Map map;
        private Geocoder geoCoder;
        private Label _lable = new Label();


        /// <summary>
        /// Constructor
        /// </summary>
        public VShops()
        {
            InitializeComponent();

            MapPage(); // create map
            //GeocoderPage();  // TODO: dont work in deployding  
            SetWorldPins();

            _lable.TextColor = Color.Black;
        }


        private async void SetWorldPins()
        {
            List<DataPin> dataList = new List<DataPin>();
            var ATMsandShops = new ViewAtmsShops();
            dataList = await ViewAtmsShops.GetPinsData();

            if (dataList.Count > 0) // test for count
            {
                foreach (DataPin item in dataList)
                {
                    var position = new Position(item.Latitutde, item.Longitude); // Latitude, Longitude
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = item.Type,
                        Address = item.Url.ToString()
                    };
                    map.Pins.Add(pin);
                }
            }
        }

        /// <summary>
        /// This Method for Create Map
        /// </summary>
        public void MapPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // You can use MapSpan.FromCenterAndRadius 
            //map.MoveToRegion (MapSpan.FromCenterAndRadius (new Position (37, -122), Distance.FromMiles (0.3)));
            // or create a new MapSpan object directly
            map.MoveToRegion(new MapSpan(new Position(0, 0), 360, 360));

            // add the slider
            var slider = new Slider(1, 18, 1);
            try
            {
                slider.ValueChanged += (sender, e) => {
                    var zoomLevel = e.NewValue; // between 1 and 18
                    var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                    Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                    if (map.VisibleRegion != null)
                        map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
                };
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Probably bad value for sender: {e}");
            }

            // create map style buttons
            var street = new Button { Text = "Street", TextColor = Color.Black};
            var hybrid = new Button { Text = "Hybrid", TextColor = Color.Black };
            var satellite = new Button { Text = "Satellite", TextColor = Color.Black };
            street.Clicked += HandleClicked;
            hybrid.Clicked += HandleClicked;
            satellite.Clicked += HandleClicked;
            var segments = new StackLayout
            {
                Spacing = 30,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = { street, hybrid, satellite }
            };


            // put the page together
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            stack.Children.Add(segments);
            stack.Children.Add(slider);
            this.atmsAndShops.Content = stack;


            // for debugging output only
            //map.PropertyChanged += (sender, e) => {
            //    Debug.WriteLine(e.PropertyName + " just changed!");
            //    if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
            //        CalculateBoundingCoordinates(map.VisibleRegion);
            //};
        }

        void HandleClicked(object sender, EventArgs e)
        {
            var b = sender as Button;
            switch (b.Text)
            {
                case "Street":
                    map.MapType = MapType.Street;
                    break;
                case "Hybrid":
                    map.MapType = MapType.Hybrid;
                    break;
                case "Satellite":
                    map.MapType = MapType.Satellite;
                    break;
            }
        }


        /// <summary>
        /// In response to this forum question http://forums.xamarin.com/discussion/22493/maps-visibleregion-bounds
        /// Useful if you need to send the bounds to a web service or otherwise calculate what
        /// pins might need to be drawn inside the currently visible viewport.
        /// </summary>
        static void CalculateBoundingCoordinates(MapSpan region)
        {
            // WARNING: I haven't tested the correctness of this exhaustively!
            var center = region.Center;
            var halfheightDegrees = region.LatitudeDegrees / 2;
            var halfwidthDegrees = region.LongitudeDegrees / 2;

            var left = center.Longitude - halfwidthDegrees;
            var right = center.Longitude + halfwidthDegrees;
            var top = center.Latitude + halfheightDegrees;
            var bottom = center.Latitude - halfheightDegrees;

            // Adjust for Internation Date Line (+/- 180 degrees longitude)
            if (left < -180) left = 180 + (180 + left);
            if (right > 180) right = (right - 180) - 180;
            // I don't wrap around north or south; I don't think the map control allows this anyway

            Debug.WriteLine("Bounding box:");
            Debug.WriteLine("                    " + top);
            Debug.WriteLine("  " + left + "                " + right);
            Debug.WriteLine("                    " + bottom);
        }

        public async void GeocoderPage()
        {
            geoCoder = new Geocoder();
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            try
            {
                var position = await locator.GetPositionAsync(4000); // is 4 seconds

                //Debug.WriteLine("Position Status: {0}", position.Timestamp);
                //Debug.WriteLine("Position Latitude: {0}", position.Latitude);
                //Debug.WriteLine("Position Longitude: {0}", position.Longitude);

                var b1 = new Button { Text = $"Reverse geocode '{position.Latitude}, {position.Longitude}'", TextColor = Color.Black };
                b1.Clicked += async (sender, e) => {
                    var fortMasonPosition = new Position(position.Latitude, position.Longitude);
                    var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
                    foreach (var a in possibleAddresses)
                    {
                        _lable.Text += a + "\n";
                    }
                };

                //var b2 = new Button { Text = "Geocode '394 Pacific Ave'" };
                //b2.Clicked += async (sender, e) => {
                //    var xamarinAddress = "394 Pacific Ave, San Francisco, California";
                //    var approximateLocation = await geoCoder.GetPositionsForAddressAsync(xamarinAddress);
                //    foreach (var p in approximateLocation)
                //    {
                //        l.Text += p.Latitude + ", " + p.Longitude + "\n";
                //    }
                //};

                //this.geocode.Content = new StackLayout // TODO uncommnet 
                //{
                //    Padding = new Thickness(0, 20, 0, 0),
                //    Children = {
                //        //b2,
                //        b1,
                //        _lable
                //    }
                //};
            }
            catch (Exception e)
            {
                await DisplayAlert("Warning", $"Data for position is unavailable!", "OK");
            }

        }

    }
}

