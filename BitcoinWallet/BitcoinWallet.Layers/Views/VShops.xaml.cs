using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Label l = new Label();


        /// <summary>
        /// Constructor
        /// </summary>
        public VShops()
        {
            InitializeComponent();

            MapPage(); // create map
            GeocoderPage();
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
            slider.ValueChanged += (sender, e) => {
                var zoomLevel = e.NewValue; // between 1 and 18
                var latlongdegrees = 360 / (Math.Pow(2, zoomLevel));
                Debug.WriteLine(zoomLevel + " -> " + latlongdegrees);
                if (map.VisibleRegion != null)
                    map.MoveToRegion(new MapSpan(map.VisibleRegion.Center, latlongdegrees, latlongdegrees));
            };


            // create map style buttons
            var street = new Button { Text = "Street" };
            var hybrid = new Button { Text = "Hybrid" };
            var satellite = new Button { Text = "Satellite" };
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
            map.PropertyChanged += (sender, e) => {
                Debug.WriteLine(e.PropertyName + " just changed!");
                if (e.PropertyName == "VisibleRegion" && map.VisibleRegion != null)
                    CalculateBoundingCoordinates(map.VisibleRegion);
            };
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
            var position = await locator.GetPositionAsync(10000);

            Debug.WriteLine("Position Status: {0}", position.Timestamp);
            Debug.WriteLine("Position Latitude: {0}", position.Latitude);
            Debug.WriteLine("Position Longitude: {0}", position.Longitude);

            var b1 = new Button { Text = $"Reverse geocode '{position.Latitude}, {position.Longitude}'" };
            b1.Clicked += async (sender, e) => {
                var fortMasonPosition = new Position(position.Latitude, position.Longitude);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
                foreach (var a in possibleAddresses)
                {
                    l.Text += a + "\n";
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

            this.geocode.Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    //b2,
                    b1,
                    l
                }
            };
        }

    }
}

