﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using BitcoinWallet.Core;
using BitcoinWallet.Helpers;
using Xamarin.Forms;

namespace BitcoinWallet.Views
{
    public partial class MainPage : TabbedPage
    {
        private List<Module> _listModules;
        private DataSyntFromXml _fromXml;

        public MainPage()
        {
            InitializeComponent();



            //XDocument doc = XDocument.Load("login.config");
            XDocument doc = null;

            if (doc != null)
            {
                _fromXml = new DataSyntFromXml(doc);
                _listModules = _fromXml.RawModules;
                foreach (var item in _listModules)
                {
                    //switch (item.Name)
                    //{
                    //    case NameModuleEnum.Name[]:
                    //    case NameModuleEnum.Name[]:
                    //}
                    int valueEnumType;
                    NameModuleEnum.Name.TryGetValue(item.Name, out valueEnumType);
                    switch (valueEnumType)
                    {
                        case 0: //alias
                            break;
                        case 1: // LoginID
                        {
                            UserMP.Text = item.Value;
                            break;
                        }
                        case 2: // pass first
                        {
                            PassMP1.Text = item.Value;
                            break;
                        }
                        case 3: // pass sec
                        {
                            PassMP2.Text = item.Value;
                            break;
                        }
                        case 4: // api code
                            break;
                        case 5: // autologon
                            break;
                        case 6: // theme
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
            else
            {
                UserMP.Text = "";
                PassMP1.Text = "";
                PassMP2.Text = "";
            }


        }



        //private void BindableObject_OnPropertyChangedopertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //     this.BarTextColor = Color.Red;
        //}

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
