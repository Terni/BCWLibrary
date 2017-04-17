﻿using BitcoinWallet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitcoinWallet.Layers.Views;
using Xamarin.Forms;
using XLabs.Data;
using XLabs.Forms.Controls;

namespace BitcoinWallet.Views
{
    public partial class VMenu : TabbedPage
    {
        private float _defaultBTC;



        public VMenu()
        {
            //Init variables
            _defaultBTC = 0;



            InitializeComponent();
            ValueBw.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            ValueBw.Text = _defaultBTC +" BTC";
            this.BindingContext = new ButtonPageViewModel();
        }

        async void Shops_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VShops());
        }
        async void Keyboard2_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VKeyboard2());
        }
        async void Payment_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VPayment());
        }
        async void Book_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VBookAdd());
        }
        async void History_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VHistory());
        }
        async void Charts_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new Expanded.Charts.Views.VCharts());
        }
        async void Detail_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VContactDetail());
        }
        async void Help_OnClicked(object sender, EventArgs e)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(new VHelp());
        }

        public class ButtonPageViewModel : ObservableObject
        {
            private bool buttonEnabled;

            public bool ButtonEnabled
            {
                get
                {
                    return this.buttonEnabled;
                }
                set
                {
                    if (this.SetProperty(ref this.buttonEnabled, value))
                    {
                        this.NotifyPropertyChanged("EnabledButtonTitle");
                    }
                }
            }

            public string EnabledButtonTitle
            {
                get
                {
                    return this.buttonEnabled ? "Enabled Image" : "Disabled image";
                }
            }
        }


    }
}
