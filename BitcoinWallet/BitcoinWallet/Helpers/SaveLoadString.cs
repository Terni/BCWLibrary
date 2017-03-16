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
    public class SaveLoadString : ContentPage
    {
        const string _fileName = "Logging.txt";
        private ISaveAndLoad _fileService;

        SaveLoadString()
        {
            _fileService = DependencyService.Get<ISaveAndLoad>();
            LoadTextAndView();
        }

        /// <summary>
        /// Method for save file text
        /// </summary>
        /// <param name="inputText"></param>
        public async void SaveText(string inputText)
        {
            var innerText = await LoadText();

            if(innerText != string.Empty) // test loading in file
                await _fileService.SaveTextAsync(_fileName, innerText + inputText);
            else
                await _fileService.SaveTextAsync(_fileName, inputText);
        }

        /// <summary>
        /// Method for load file text
        /// </summary>
        /// <returns>string</returns>
        public async Task<string> LoadText()
        {
            string outputText;
            if (_fileService.FileExists(_fileName))
            {
                outputText = await _fileService.LoadTextAsync(_fileName);
            }
            else
            {
                return string.Empty;
            }

            return outputText;
        }

        /// <summary>
        /// Method for load text from file on ContentPage
        /// </summary>
        public async void LoadTextAndView()
        {
            var output = new Label { Text = "" };
            if (_fileService.FileExists(_fileName))
            {
                output.Text = await _fileService.LoadTextAsync(_fileName);
            }

            Content = new ScrollView
            {
                Content = new StackLayout
                {
                    Padding = new Thickness(0, 20, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    Children = {
                        new Label {
                            Text = "Logging Text",
                            FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
                            FontAttributes = FontAttributes.Bold
                        },
                        output
                    }
                }

            };
        }
    }
}
