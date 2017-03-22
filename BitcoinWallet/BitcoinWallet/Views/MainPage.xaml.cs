using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using BitcoinWallet.Core;
using BitcoinWallet.Helpers;
using BitcoinWallet.Models;
using Xamarin.Forms;
using System.Reflection;
using System.Threading.Tasks;

namespace BitcoinWallet.Views
{
    public partial class MainPage : TabbedPage
    {
        private List<Modules> _listModules;
        private DataSyntFromXml _fromXml;
        private Stream streamFile;

        public MainPage()
        {
            InitializeComponent();

            #region Loading LoginConfig.xml
            //var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream("BitcoinWallet.login.xml");
            #endregion
            LoadXmlFile instLoadXmlFile = new LoadXmlFile();
            streamFile = instLoadXmlFile.Streams;

            if (streamFile != null)
            {
                XDocument doc = XDocument.Load(streamFile);
                _fromXml = new DataSyntFromXml(doc);
                WaitData(); // here method wait on data from xml file

            }

            if (UserMP.Text == null)
            {
                UserMP.Text = "";
                PassMP1.Text = "";
                PassMP2.Text = "";
            }
        }

        private async void WaitData()
        {
            var result = await _fromXml.LoadXMLData();
            if ((_listModules = _fromXml.RawModules) != null && result)
            {
                foreach (var item in _listModules)
                {
                    NameModule valueEnumType;
                    NameModuleEnum.Name.TryGetValue(item.Name, out valueEnumType);
                    switch (valueEnumType)
                    {
                        case NameModule.Alias:
                            break;
                        case NameModule.LoginID:
                            {
                                UserMP.Text = item.Value;
                                break;
                            }
                        case NameModule.PasswordFirst:
                            {
                                PassMP1.Text = item.Value;
                                break;
                            }
                        case NameModule.PasswordSecond:
                            {
                                PassMP2.Text = item.Value;
                                break;
                            }
                        case NameModule.api_code:
                            break;
                        case NameModule.autologon:
                            break;
                        case NameModule.Theme:
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }

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
