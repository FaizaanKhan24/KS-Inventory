using System;
using System.Collections.Generic;
using System.Windows.Input;
using KSInventory.Database;
using KSInventory.Database.Models;
using KSInventory.Models.Enums;
using KSInventory.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.ViewModels
{
    [Preserve(AllMembers = true)]
    public class HomeViewModel : BaseViewModel
    {
        #region Private Variables

        protected Repository Repository { get; }

        #endregion

        #region Commands

        public ICommand NewProductCommand { get; set; }
        public ICommand NewSaleCommand { get; set; }
        public ICommand NewStockCommand { get; set; }
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
            NewStockCommand = new Command(NavigateToNewStockPage);
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

        private async void NavigateToNewStockPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddStockPage());
        }

        #endregion
    }
}
