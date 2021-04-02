using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KSInventory.Database;
using KSInventory.Database.Models;
using KSInventory.Views;
using Xamarin.Forms;

namespace KSInventory.ViewModels
{
    public class ProductStockViewModel : BaseViewModel
    {
        #region Private Variables

        private bool isUpdateStockButtonEnabled;
        private string newStockQuantity;
        private DateTime minimumDate;
        private DateTime maximumDate;
        private ProductDetails product;
        private ObservableCollection<ProductStockDetails> productStocks;
        private ProductStockDetails selectedProductStock;

        #endregion

        #region Constructors

        public ProductStockViewModel(ProductDetails productDetails)
        {
            this.Product = productDetails;
            var orderedStockDetails = productDetails.StockDetails.OrderByDescending(x => x.Date).ToList();
            this.ProductStocks = new ObservableCollection<ProductStockDetails>(orderedStockDetails);
            InitializeProperties();
            InitializeCommands();
        }

        #endregion

        #region Commands

        public ICommand EditStockCommand { get; set; }
        public ICommand DeleteStockCommand { get; set; }
        public ICommand UpdateStockCommand { get; set; }

        #endregion

        #region Properties

        public bool IsUpdateStockButtonEnabled
        {
            get { return isUpdateStockButtonEnabled; }
            set
            {
                isUpdateStockButtonEnabled = value;
                OnPropertyChanged();
                ((Command)UpdateStockCommand).ChangeCanExecute();
            }
        }
        public string NewStockQuantity
        {
            get { return newStockQuantity; }
            set { newStockQuantity = value; OnPropertyChanged(); }
        }
        public ProductDetails Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ProductStockDetails> ProductStocks
        {
            get { return productStocks; }
            set { productStocks = value; OnPropertyChanged(); }
        }
        public DateTime MinimumDate
        {
            get { return minimumDate; }
            set { minimumDate = value; OnPropertyChanged(); }
        }
        public DateTime MaximumDate
        {
            get { return maximumDate; }
            set { maximumDate = value; OnPropertyChanged(); }
        }
        public ProductStockDetails SelectedProductStock
        {
            get { return selectedProductStock; }
            set { selectedProductStock = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        private void InitializeProperties()
        {
            MaximumDate = DateTime.Now;
            MinimumDate = new DateTime(2021, 03, 05);
        }

        private void InitializeCommands()
        {
            EditStockCommand = new Command<ProductStockDetails>(NavigateToEditProductStockPage);
            DeleteStockCommand = new Command<ProductStockDetails>(DeleteStocksButtonTapped);
            UpdateStockCommand = new Command(UpdateProductStock, CanEnableStockUpdateButton());
        }

        #region Edit Stock

        private async void NavigateToEditProductStockPage(ProductStockDetails productStockDetails)
        {
            if (productStockDetails != null)
            {
                SelectedProductStock = productStockDetails;
                newStockQuantity = SelectedProductStock.StocksOrdered.ToString();
            }
            await Application.Current.MainPage.Navigation.PushAsync(new EditProductStockPage(this));
        }

        private Func<bool> CanEnableStockUpdateButton()
        {
            return new Func<bool>(() => { return IsUpdateStockButtonEnabled; });
        }

        public void ShouldEnableUpdateButton()
        {
            int soldQuantityCount = int.TryParse(NewStockQuantity, out int temp) ? temp : 0;
            if (soldQuantityCount > 0)
            {
                IsUpdateStockButtonEnabled = true;
                return;
            }
            IsUpdateStockButtonEnabled = false;
        }

        private async void UpdateProductStock()
        {
            try
            {
                IsBusy = true;
                bool isProductStockEdited = false;
                SelectedProductStock.StocksOrdered = int.Parse(NewStockQuantity);
                DateTime editedDateTime = SelectedProductStock.Date;
                var dateProductStock = ProductStocks.Where(x => x.Date == editedDateTime).ToList();

                if (dateProductStock != null && dateProductStock.Count == 1)
                {
                    isProductStockEdited = await UpdateStock(SelectedProductStock);
                }
                else if (dateProductStock != null && dateProductStock.Count > 1)
                {
                    var totalDayStock = dateProductStock.Sum(x => x.StocksOrdered);
                    var productDayStock = dateProductStock[0];
                    SelectedProductStock.StocksOrdered = totalDayStock;
                    isProductStockEdited = await UpdateStock(SelectedProductStock);
                    if (isProductStockEdited)
                    {
                        var extraStock = dateProductStock.Where(x => x.Id != SelectedProductStock.Id).ToList();
                        foreach (var stock in extraStock)
                        {
                            bool isProductSaleDeleted = await ProductStocksRepository.DeleteProductStock(stock);
                            if (isProductSaleDeleted)
                                ProductStocks.Remove(stock);
                        }
                    }
                }
                IsBusy = false;

                if (isProductStockEdited)
                {
                    var orderedProductStocks = ProductStocks.OrderByDescending(x => x.Date).ToList();
                    Product.StockDetails = orderedProductStocks;
                    MessagingCenter.Send<object, ProductDetails>(this, "UpdateProductDetails", Product);
                    ProductStocks = new ObservableCollection<ProductStockDetails>(orderedProductStocks);
                    await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product sale is updated successfully.", "Ok");
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

        private async Task<bool> UpdateStock(ProductStockDetails productStockDetails)
        {
            var isProductStockEdited = await ProductStocksRepository.UpdateProductStock(productStockDetails);
            if (isProductStockEdited)
            {
                int editedSaleIndex = ProductStocks.IndexOf(ProductStocks.Where(x => x.Id == productStockDetails.Id).FirstOrDefault());
                ProductStocks[editedSaleIndex] = productStockDetails;
            }
            return isProductStockEdited;
        }

        #endregion

        #region Delete Stock

        private async void DeleteStocksButtonTapped(ProductStockDetails productStockDetails)
        {
            bool canDeleteProductStock = await Application.Current.MainPage.DisplayAlert("Alert", "Do you want to delete the selected stock details?", "Yes", "No");
            if (canDeleteProductStock)
                DeleteProductStockData(productStockDetails);
        }

        private async void DeleteProductStockData(ProductStockDetails productStockDetails)
        {
            try
            {
                if(productStockDetails != null)
                {
                    IsBusy = true;
                    var isProductStockDeleted = await ProductStocksRepository.DeleteProductStock(productStockDetails);
                    IsBusy = false;
                    if (isProductStockDeleted)
                    {
                        ProductStocks.Remove(productStockDetails);
                        Product.StockDetails = ProductStocks.ToList();
                        MessagingCenter.Send<object, ProductDetails>(this, "UpdateProductDetails", Product);
                        await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product stock is deleted successfully.", "Ok");
                    }
                    else
                        await Application.Current.MainPage.DisplayAlert("Alert!", "Something went wrong.", "Ok");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        #endregion

        #endregion
    }
}
