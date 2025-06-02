using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Interface;
using Xamarin.Forms;

namespace BitcoinWallet.Helpers
{
    /// <summary>
    /// This page includes input boxes and buttons that allow the text to be
    /// saved-to and loaded-from a file. The actual file operations are done
    /// against an interface, which must be implemented in each of the app
    /// platform projects.
    /// </summary>
    public class SaveAndLoadText : ContentPage
    {
        const string fileName = "Logging.txt";
        Button loadButton;
        Button saveButton;

        SaveAndLoadText()
        {
            LoadText();
        }

        public void SaveText()
        {
            var fileService = DependencyService.Get<ISaveAndLoad>();

            var input = new Entry { Text = "" };

            saveButton = new Button { Text = "Save" };

            saveButton.Clicked += async (sender, e) => {
                saveButton.IsEnabled = false;
                // uses the Interface defined in this project, and the implementations that must
                // be written in the iOS, Android and WinPhone app projects to do the actual file manipulation

                await fileService.SaveTextAsync(fileName, input.Text);
                saveButton.IsEnabled = true;
            };

            var buttonLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { saveButton }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label {
                        Text = "Save Text (PCL)",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label { Text = "Type below and press Save" },
                    input,
                    buttonLayout
                }
            };
        }

        public void LoadText()
        {
            var fileService = DependencyService.Get<ISaveAndLoad>();
            var output = new Label { Text = "" };
            loadButton = new Button { Text = "Load" };
            loadButton.Clicked += async (sender, e) => {
                loadButton.IsEnabled = false;

                // uses the Interface defined in this project, and the implementations that must
                // be written in the iOS, Android and WinPhone app projects to do the actual file manipulation
                output.Text = await fileService.LoadTextAsync(fileName);
                loadButton.IsEnabled = true;
            };
            loadButton.IsEnabled = fileService.FileExists(fileName);

            var buttonLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children = { loadButton }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Label {
                        Text = "Load Text (PCL)",
                        FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    },
                    new Label { Text = "Type below and press Load" },
                    buttonLayout,
                    output
                }
            };
        }
    }
}
