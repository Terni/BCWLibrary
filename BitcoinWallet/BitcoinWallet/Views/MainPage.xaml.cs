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
using Android.Util;
using Bitcoin.APIv2Client.Models;
using BitcoinWallet.Layers.Models;
using Info.Blockchain.API.BlockExplorer;

namespace BitcoinWallet.Views
{
    public partial class MainPage : TabbedPage
    {
        private List<Modules> _listModules;
        private DataSyntFromXml _fromXml;
        private Stream streamFile;
        private bool IsPasswordSecond;
        private string PasswordSecondValue;

        public MainPage()
        {
            InitializeComponent();
            IsPasswordSecond = Pass2MP.IsVisible;

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
            }

        }


        private async void InitDataLocalization()
        {
            var result = await _fromXml.LoadXMLData();

            if ((_listModules = _fromXml.RawModules) != null && result)
            {
                XmlList.SetXmlList(_listModules); // add all values to static list

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
                            IDWallet.Placeholder = Loc.Localize("IdWallet", "Id Wallet");
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

            WaitData(); // here method wait on data from xml file
        }

        /// <summary>
        /// Method for fill values
        /// </summary>
        private void WaitData()
        {
            //var result = await _fromXml.LoadXMLData();

            if (_listModules != null)
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
                            IDWallet.Text = DataLogon.IdWallet = item.Value;
                            break;
                        }
                        case NameModule.PasswordFirst:
                        {
                            Pass1MP.Text = DataLogon.Password = item.Value;
                            break;
                        }
                        case NameModule.PasswordSecond:
                        {
                            PasswordSecondValue = DataLogon.PasswordSecond = item.Value;
                            if (IsPasswordSecond)
                            {
                                Pass2MP.Text = PasswordSecondValue;
                            }
                            else
                            {
                                Pass2MP.Text = PasswordSecondValue = "";
                            }
                            break;
                        }
                        case NameModule.api_code:
                        {
                            ApiCodeMP.Text = DataLogon.ApiCode = item.Value;
                            break;
                        }
                        case NameModule.autologon:
                            break;
                        case NameModule.Theme:
                            break;
                        default:
                            continue; // orders key
                    }
                }
            }
        }

        async void Loging_OnClicked(object sender, EventArgs e)
        {
            //Init all fields
            ApiLogon.IdentifierWallet = IDWallet.Text;
            ApiLogon.Password = Pass1MP.Text;
            if (Pass2MP.IsVisible)
                ApiLogon.PasswordSecond = Pass2MP.Text;

            if (string.IsNullOrWhiteSpace(ApiLogon.IdentifierWallet) || string.IsNullOrWhiteSpace(ApiLogon.Password)) // test logon strings
            {
                await DisplayAlert("Warning", $"ID Wallet or Password are bad filled!", "OK");
            }
            else if (ApiLogon.IdentifierWallet.Length != 36)
            {
                await DisplayAlert("Warning", $"ID Wallet have bad length!", "OK");
            }
            else if (string.IsNullOrWhiteSpace(ApiLogon.PasswordSecond) && Pass2MP.IsVisible)
            {
                await DisplayAlert("Warning", $"Second Password are bad filled!", "OK");
            }
            else
            {
                //For ID Wallet and password
                //ApiLogon.IdentifierWallet =  Logon.IdentifierWallet = DataLogon.IdWallet;
                //ApiLogon.Password = Logon.Password = DataLogon.Password;

                //if (!string.IsNullOrWhiteSpace(DataLogon.PasswordSecond))
                //    ApiLogon.PasswordSecond = Logon.PasswordSecond = DataLogon.PasswordSecond;
                //else
                //{
                //    ApiLogon.PasswordSecond = Logon.PasswordSecond = null;
                //}

                if (!string.IsNullOrWhiteSpace(DataLogon.ApiCode))
                    ApiLogon.ApiCode = Logon.ApiCode = DataLogon.ApiCode;

                try
                {
                    new Logon(); // init Wallet

                    ApiLogon.Balance = await BitcoinWallet.Layers.Models.ApiLogon.Wallet.GetBalanceAsync();

                    Logon.Balance = (int)ApiLogon.Balance.Btc;
                    Debug.WriteLine($"Balance is: {Logon.Balance}");

                    if (Navigation != null)
                        await Navigation.PushModalAsync(new VMenuItems());
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error from server or client! Error is: {ex}");
                    //Logging.Debug($"Error from server or client! Error is: {ex}");

                    if (Navigation != null) //TODO: HACK fot testing
                        await Navigation.PushModalAsync(new VMenuItems());
                }
            }
        }

        private void SwitchCell_OnOnChanged(object sender, ToggledEventArgs e)
        {
            IsPasswordSecond = Pass2MP.IsVisible = framePass2MP.IsVisible = (sender as SwitchCell).On;
            if (IsPasswordSecond)
            {
                Pass2MP.Text = DataLogon.PasswordSecond;
            }
        }
    }
}
