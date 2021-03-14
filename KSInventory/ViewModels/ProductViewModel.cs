using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using KSInventory.Models;
using KSInventory.Views;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace KSInventory.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        #region Private variables

        #region Edit Page

        private bool isUpdateButtonEnabled;
        private string newQuantitySold;
        private DateTime minimumDate;
        private DateTime maximumDate;
        private DateTime selectedDate;
        private ProductSalesDetails selectedProductSale;

        #endregion

        private ProductDetails product;
        private List<ChartEntry> chartEntries;

        #endregion

        #region Command

        public ICommand EditSalesCommand { get; set; }
        public ICommand DeleteSalesCommand { get; set; }
        public ICommand UpdateSalesCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }

        #endregion

        #region Constructor

        public ProductViewModel(ProductDetails productDetails)
        {
            this.Product = productDetails;
            var orderedSalesDetails = productDetails.SaleDetails.OrderByDescending(x => x.Date).ToList();
            this.Product.SaleDetails = orderedSalesDetails;
            InitializeProperties();
            InitializeCommands();
            Device.BeginInvokeOnMainThread(() =>
            {
                SetChartEntries();
            });
        }

        #endregion

        #region Properties

        #region Edit Page

        public bool IsUpdateButtonEnabled
        {
            get { return isUpdateButtonEnabled; }
            set
            {
                isUpdateButtonEnabled = value;
                OnPropertyChanged();
                ((Command)UpdateSalesCommand).ChangeCanExecute();
            }
        }
        public string NewQuantitySold
        {
            get { return newQuantitySold; }
            set { newQuantitySold = value; OnPropertyChanged(); }
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
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(); }
        }
        public ProductSalesDetails SelectedProductSale
        {
            get { return selectedProductSale; }
            set { selectedProductSale = value; OnPropertyChanged(); }
        }

        #endregion

        public ProductDetails Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }
        public List<ChartEntry> ChartEntries
        {
            get { return chartEntries; }
            set { chartEntries = value; OnPropertyChanged(); }
        }

        #endregion

        #region Methods

        private void InitializeProperties()
        {
            MaximumDate = DateTime.Now;
            MinimumDate = new DateTime(2021, 01, 01);
            ChartEntries = new List<ChartEntry>();
        }

        private void InitializeCommands()
        {
            EditSalesCommand = new Command<ProductSalesDetails>(NavigateToEditProductSalePage);
            DeleteSalesCommand = new Command(DeleteSalesButtonTapped);
            UpdateSalesCommand = new Command(UpdateProductSales, CanEnableUpdateButton());
            EditProductCommand = new Command(NavigateToEditProductPage);
            DeleteProductCommand = new Command(DeleteProductButtonTapped);
        }

        private void SetChartEntries()
        {
            if (Product.SaleDetails != null && Product.SaleDetails.Count > 0)
            {
                Dictionary<string, int> monthlySales = GetMonthlySales();

                foreach (var sale in monthlySales)
                {
                    ChartEntries.Add(new ChartEntry(sale.Value)
                    {
                        Label = sale.Key,
                        ValueLabel = sale.Value.ToString(),
                        Color = SKColor.Parse(" #ffa500")
                    });
                }
            }
        }

        private Dictionary<string, int> GetMonthlySales()
        {
            var groupedSalesDetails = Product.SaleDetails.GroupBy(x => new { x.Date.Year, x.Date.Month }).ToList();
            var orderedSalesDetails = groupedSalesDetails.OrderBy(x => x.Key.Year).ThenBy(x => x.Key.Month).ToList();

            Dictionary<string, int> monthlySales = new Dictionary<string, int>();
            foreach (var salesDetails in orderedSalesDetails)
            {
                var salesSum = salesDetails.Sum(x => x.TotalSold);
                var salesKey = salesDetails.Key;
                string monthAbbreviation = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(salesDetails.Key.Month);
                string key = monthAbbreviation + " " + salesDetails.Key.Year.ToString();
                monthlySales.Add(key, salesSum);
            }

            return monthlySales;
        }

        #region Delete Sale

        private async void DeleteSalesButtonTapped()
        {
            bool canDeleteProductSale = await Application.Current.MainPage.DisplayAlert("Alert", "Do you want to delete the sales details for this page.", "Yes", "No");
            if (canDeleteProductSale)
                DeleteProductSale();
        }

        private async void DeleteProductSale()
        {
            // TO DO Call Delete product Sale API.
            await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product sale is deleted successfully.", "Ok");
        }

        #endregion

        #region Edit Sale

        private Func<bool> CanEnableUpdateButton()
        {
            return new Func<bool>(() => { return IsUpdateButtonEnabled; });
        }

        public void ShouldEnableUpdateButton()
        {
            int soldQuantityCount = int.TryParse(NewQuantitySold, out int temp) ? temp : 0;
            if (soldQuantityCount > 0)
            {
                IsUpdateButtonEnabled = true;
                return;
            }
            IsUpdateButtonEnabled = false;
        }

        private async void NavigateToEditProductSalePage(ProductSalesDetails productSales)
        {
            if (productSales != null)
            {
                SelectedProductSale = productSales;
                NewQuantitySold = SelectedProductSale.TotalSold.ToString();
            }
            await Application.Current.MainPage.Navigation.PushAsync(new EditProductSalePage(this));
        }

        private async void UpdateProductSales()
        {
            // TO DO Call Update Product Sales API.
            await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product sale is updated successfully.", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion

        #region Delete Product

        private async void DeleteProductButtonTapped()
        {
            bool canDeleteProduct = await Application.Current.MainPage.DisplayAlert("Alert", "Do you want to delete this product?\nAll data about the product will be deleted.", "Yes", "No");
            if (canDeleteProduct)
                DeleteProduct();
        }

        private async void DeleteProduct()
        {
            // TO DO Call Delete product API.
            await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product is deleted successfully.", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion

        #region Edit Product

        private async void NavigateToEditProductPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EditProductPage(Product));
        }

        #endregion

        #endregion
    }
}
