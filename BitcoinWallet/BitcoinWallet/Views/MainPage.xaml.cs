using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using BitcoinWallet.Core;
using BitcoinWallet.Helpers;
using BitcoinWallet.Models;
using BitcoinWallet.ViewModels;
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
                InitDataLocalization(); // init localization keys
                WaitData(); // here method wait on data from xml file

            }

            //// Whipe text field
            //if (UserMP.Text == null)
            //{
            //    UserMP.Text = "";
            //    Pass1MP.Text = "";
            //    Pass2MP.Text = "";
            //}
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
                            Pass1MP.Text = item.Value;
                            break;
                        }
                        case NameModule.PasswordSecond:
                        {
                            Pass2MP.Text = item.Value;
                            break;
                        }
                        case NameModule.api_code:
                        {
                            ApiCodeMP.Text = item.Value;
                            break;
                        }
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

        private async void InitDataLocalization()
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
                        {
                            AlsMP.Placeholder = Loc.Localize("Alias", "Alias");
                            break;
                        }
                        case NameModule.LoginID:
                        {
                            UserMP.Placeholder = Loc.Localize("IdWallet", "Id Wallet");
                            break;
                        }
                        case NameModule.PasswordFirst:
                        {
                            Pass1MP.Placeholder = Loc.Localize("Password", "Password");
                            break;
                        }
                        case NameModule.PasswordSecond:
                        {
                            Pass2MP.Placeholder = Loc.Localize("SecPassword", "Second Password");
                            break;
                        }
                        case NameModule.api_code:
                        {
                            ApiCodeMP.Placeholder = Loc.Localize("ApiCode", "Api Code");
                            break;
                        }
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

        async void Loging_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VMenuItems());
            //Navigation.PushAsync(new menuPage());
        }
    }
}
