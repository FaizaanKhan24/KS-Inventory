using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using KSInventory.Helper;
using KSInventory.Models;
using KSInventory.Views;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.ViewModels
{
    [Preserve(AllMembers = true)]
    public class ProductListViewMode : BaseViewModel
    {
        #region Private Variables

        private string searchText;
        private List<FilteredProducts> filteredProducts;
        private List<ProductDetails> searchedProductDetails;

        #endregion

        #region Commands

        public ICommand ProductCommand { get; set; }

        #endregion

        #region Constructor

        public ProductListViewMode()
        {
            InitializeCommands();
            InitializeProperties();
        }

        #endregion

        #region Properties

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged(); }
        }
        public List<FilteredProducts> FilteredProducts
        {
            get { return filteredProducts; }
            set { filteredProducts = value; OnPropertyChanged(); }
        }
        public List<ProductDetails> SearchedProductDetails
        {
            get { return searchedProductDetails; }
            set { searchedProductDetails = value; OnPropertyChanged(); }
        }
        public List<ProductDetails> ProductDetails { get; set; }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            ProductCommand = new Command<ProductDetails>(NavigateToProductPage);
        }

        private void InitializeProperties()
        {
            ProductDetails = DummyDataGenerator.GetProductDetails();
            FilteredProducts = GetFilteredProducts(ProductDetails);
            SearchedProductDetails = new List<ProductDetails>();
        }

        private async void NavigateToProductPage(ProductDetails product)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductPage(product));
        }

        private List<FilteredProducts> GetFilteredProducts(List<ProductDetails> productDetails)
        {
            if (productDetails != null && productDetails.Count > 0)
            {
                List<FilteredProducts> filteredProducts = new List<FilteredProducts>()
                {
                    new FilteredProducts()
                    {
                        ProductCategoryColor = Color.Red,
                        ProductCategoryName = "Red",
                        CategoryProducts = productDetails.Where(x=>x.Color == Models.Enums.Colors.Red).ToList()
                    },
                    new FilteredProducts()
                    {
                        ProductCategoryName = "Black",
                        ProductCategoryColor = Color.Black,
                        CategoryProducts = productDetails.Where(x=>x.Color == Models.Enums.Colors.Black).ToList()
                    },
                    new FilteredProducts()
                    {
                        ProductCategoryName = "Blue",
                        ProductCategoryColor = Color.Blue,
                        CategoryProducts = productDetails.Where(x=>x.Color == Models.Enums.Colors.Blue).ToList()
                    },
                    new FilteredProducts()
                    {
                        ProductCategoryName = "White",
                        ProductCategoryColor = Color.Wheat,
                        CategoryProducts = productDetails.Where(x=>x.Color == Models.Enums.Colors.White).ToList()
                    }
                };

                return filteredProducts;
            }
            return null;
        }

        public void SearchProduct()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                SearchedProductDetails = ProductDetails.Where(x => x.ProductName.ToLower().Contains(SearchText)).ToList();
                return;
            }
            SearchedProductDetails = new List<ProductDetails>();
        }

        #endregion
    }
}
