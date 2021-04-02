using System;
using System.Windows.Input;
using KSInventory.Database;
using KSInventory.Database.Models;
using Xamarin.Forms;

namespace KSInventory.ViewModels
{
    public class EditProductViewModel : BaseViewModel
    {
        #region Private Variables

        private string productName;
        private string productSKU;
        private bool isUpdateButtonEnabled;
        private ProductDetails productDetails;

        #endregion

        #region Constructor

        public EditProductViewModel(ProductDetails product)
        {
            this.productDetails = product;
            ProductName = product.ProductName;
            ProductSKU = product.ProductSKU;
            InitializeCommands();
        }

        #endregion

        #region Command

        public ICommand UpdateCommand { get; set; }

        #endregion

        #region Properties

        public string ProductName
        {
            get { return productName; }
            set { productName = value; OnPropertyChanged(); }
        }
        public string ProductSKU
        {
            get { return productSKU; }
            set { productSKU = value; OnPropertyChanged(); }
        }
        public bool IsUpdateButtonEnabled
        {
            get { return isUpdateButtonEnabled; }
            set
            {
                isUpdateButtonEnabled = value;
                OnPropertyChanged();
                ((Command)UpdateCommand).ChangeCanExecute();
            }
        }

        #endregion

        #region Method

        private void InitializeCommands()
        {
            UpdateCommand = new Command(UpdateProductDetails, CanExecuteUpdateButton());
        }

        private Func<bool> CanExecuteUpdateButton()
        {
            return new Func<bool>(() => IsUpdateButtonEnabled);
        }

        private async void UpdateProductDetails()
        {
            // TO DO: Integrate the Update Product Details API.
            try
            {
                IsBusy = true;
                productDetails.ProductName = ProductName;
                productDetails.ProductSKU = ProductSKU;
                var isProductDetailsUpdated = await ProductRepository.UpdateProduct(productDetails);
                IsBusy = false;
                if (isProductDetailsUpdated)
                {
                    MessagingCenter.Send<object, ProductDetails>(this, "UpdateProductDetails", productDetails);
                    await Application.Current.MainPage.DisplayAlert("Success!", "Product details have been successfully updated.", "Ok");
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Alert!", "Something went wrong.", "Ok");
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        public void ShouldEnableUpdateButton()
        {
            if (!string.IsNullOrEmpty(ProductName) && !string.IsNullOrEmpty(ProductSKU))
            {
                IsUpdateButtonEnabled = true;
                return;
            }
            IsUpdateButtonEnabled = false;
        }

        #endregion
    }
}
