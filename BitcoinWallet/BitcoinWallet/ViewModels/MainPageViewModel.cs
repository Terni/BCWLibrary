using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitcoinWallet.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// Variables
        /// </summary>
        private string _title;
        private BwStyle _bwStyleInstance;

        /// <summary>
        /// Property
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        #region MyRegion
        /// <summary>
        /// Constructor MainPageViewModel
        /// </summary>
        public MainPageViewModel()
        {
            _bwStyleInstance = new BwStyle();
        }
        #endregion

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
