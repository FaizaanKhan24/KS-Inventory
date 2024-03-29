﻿using System;
using System.Windows.Input;
using KSInventory.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.ViewModels
{
    [Preserve(AllMembers = true)]
    public class HomeViewModel : BaseViewModel
    {
        #region Private Variables

        

        #endregion

        #region Commands

        public ICommand NewProductCommand { get; set; }
        public ICommand NewSaleCommand { get; set; }
        public ICommand ViewProductsCommand { get; set; }

        #endregion

        #region Constructors

        public HomeViewModel()
        {
            InitializeCommands();
            
        }

        #endregion

        #region Properties



        #endregion

        #region Methods

        private void InitializeCommands()
        {
            NewProductCommand = new Command(NavigateToNewProductPage);
            NewSaleCommand = new Command(NavigateToNewSalePage);
            ViewProductsCommand = new Command(NavigateToProductListPage);
        }

        private async void NavigateToNewProductPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddProductPage());
        }

        private async void NavigateToProductListPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductListPage());
        }

        private async void NavigateToNewSalePage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddNewSalePage());
        }

        #endregion
    }
}
