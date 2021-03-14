using System;
using System.Windows.Input;
using KSInventory.Models;
using Xamarin.Forms;

namespace KSInventory.ViewModels
{
    public class EditProductViewModel : BaseViewModel
    {
        #region Private Variables

        private string productName;
        private string productSKU;
        private bool isUpdateButtonEnabled;

        #endregion

        #region Constructor

        public EditProductViewModel(ProductDetails product)
        {
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

            await Application.Current.MainPage.DisplayAlert("Success!", "Product details have been successfully updated.", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
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
