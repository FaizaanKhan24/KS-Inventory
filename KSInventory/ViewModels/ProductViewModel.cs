using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KSInventory.Database;
using KSInventory.Database.Models;
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
        private ObservableCollection<ProductSalesDetails> productSales;
        private List<ChartEntry> chartEntries;

        #endregion

        #region Command

        public ICommand EditSalesCommand { get; set; }
        public ICommand DeleteSalesCommand { get; set; }
        public ICommand UpdateSalesCommand { get; set; }
        public ICommand EditProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand ProductStockDetailsCommand { get; set; }

        #endregion

        #region Constructor

        public ProductViewModel(ProductDetails productDetails)
        {
            this.Product = productDetails;
            var orderedSalesDetails = productDetails.SalesDetails.OrderByDescending(x => x.Date).ToList();
            this.ProductSales = new ObservableCollection<ProductSalesDetails>(orderedSalesDetails);
            InitializeProperties();
            InitializeCommands();
            Device.BeginInvokeOnMainThread(() =>
            {
                SetChartEntries();
            });

            MessagingCenter.Subscribe<object, ProductDetails>(this, "UpdateProductDetails", (sender, args) =>
            {
                Product = args;
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
        public ObservableCollection<ProductSalesDetails> ProductSales
        {
            get { return productSales; }
            set { productSales = value; OnPropertyChanged(); }
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
            MinimumDate = new DateTime(2021, 03, 05);
            ChartEntries = new List<ChartEntry>();
        }

        private void InitializeCommands()
        {
            EditSalesCommand = new Command<ProductSalesDetails>(NavigateToEditProductSalePage);
            DeleteSalesCommand = new Command<ProductSalesDetails>(DeleteSalesButtonTapped);
            UpdateSalesCommand = new Command(UpdateProductSales, CanEnableUpdateButton());
            EditProductCommand = new Command(NavigateToEditProductPage);
            DeleteProductCommand = new Command(DeleteProductButtonTapped);
            ProductStockDetailsCommand = new Command(NavigateToProductStockPage);
        }

        private void SetChartEntries()
        {
            if (Product.SalesDetails != null && Product.SalesDetails.Count > 0)
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

        private void ResetChartEntries()
        {
            ChartEntries = new List<ChartEntry>();
            SetChartEntries();
        }

        private Dictionary<string, int> GetMonthlySales()
        {
            var groupedSalesDetails = Product.SalesDetails.GroupBy(x => new { x.Date.Year, x.Date.Month }).ToList();
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

        private async void DeleteSalesButtonTapped(ProductSalesDetails productSalesDetails)
        {
            bool canDeleteProductSale = await Application.Current.MainPage.DisplayAlert("Alert", "Do you want to delete the selected sales details?", "Yes", "No");
            if (canDeleteProductSale)
                DeleteProductSale(productSalesDetails);
        }

        private async void DeleteProductSale(ProductSalesDetails productSalesDetails)
        {
            // TO DO Call Delete product Sale API.
            try
            {
                if(productSalesDetails != null)
                {
                    IsBusy = true;
                    var isProductSalesDeleted = await ProductSalesRepository.DeleteProductSale(productSalesDetails);
                    IsBusy = false;
                    if (isProductSalesDeleted)
                    {
                        ProductSales.Remove(productSalesDetails);
                        Product.SalesDetails = ProductSales.ToList();
                        ResetChartEntries();
                        await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product sale is deleted successfully.", "Ok");
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
            try
            {
                IsBusy = true;
                bool isProductSaleEdited = false;
                SelectedProductSale.TotalSold = int.Parse(NewQuantitySold);
                DateTime editedDateTime = SelectedProductSale.Date;
                var dateProductSales = ProductSales.Where(x => x.Date == editedDateTime).ToList();

                if (dateProductSales != null && dateProductSales.Count == 1)
                {
                    isProductSaleEdited = await UpdateSale(SelectedProductSale);
                }
                else if (dateProductSales != null && dateProductSales.Count > 1)
                {
                    var totalDaySale = dateProductSales.Sum(x => x.TotalSold);
                    var productDaySale = dateProductSales[0];
                    SelectedProductSale.TotalSold = totalDaySale;
                    isProductSaleEdited = await UpdateSale(SelectedProductSale);
                    if (isProductSaleEdited)
                    {
                        var extraSale = dateProductSales.Where(x => x.Id != SelectedProductSale.Id).ToList();
                        foreach (var sale in extraSale)
                        {
                            bool isProductSaleDeleted = await ProductSalesRepository.DeleteProductSale(sale);
                            if (isProductSaleDeleted)
                                ProductSales.Remove(sale);
                        }
                    }
                }
                IsBusy = false;
                if (isProductSaleEdited)
                {
                    var orderedProductSales = ProductSales.OrderByDescending(x => x.Date).ToList();
                    Product.SalesDetails = orderedProductSales;
                    ProductSales = new ObservableCollection<ProductSalesDetails>(orderedProductSales);
                    ResetChartEntries();
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

        private async Task<bool> UpdateSale(ProductSalesDetails productSalesDetails)
        {
            var isProductSaleEdited = await ProductSalesRepository.UpdateProductSale(productSalesDetails);
            if (isProductSaleEdited)
            {
                int editedSaleIndex = ProductSales.IndexOf(ProductSales.Where(x => x.Id == productSalesDetails.Id).FirstOrDefault());
                ProductSales[editedSaleIndex] = productSalesDetails;
            }
            return isProductSaleEdited;
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
            try
            {
                IsBusy = true;
                var isProductDeleted = await ProductRepository.DeleteProduct(Product);
                IsBusy = false;
                if (isProductDeleted)
                {
                    MessagingCenter.Send<object, ProductDetails>(this, "DeleteProduct", Product);
                    await Application.Current.MainPage.DisplayAlert("Success!", "The selected Product is deleted successfully.", "Ok");
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

        #endregion

        #region Edit Product

        private async void NavigateToEditProductPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new EditProductPage(Product));
        }

        #endregion

        #region Product Stocks

        private async void NavigateToProductStockPage()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductStockingPage(Product));
        }

        #endregion

        #endregion
    }
}
