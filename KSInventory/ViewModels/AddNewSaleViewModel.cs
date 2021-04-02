﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KSInventory.Helper;
using KSInventory.Database.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using KSInventory.Database.Models.Enums;
using KSInventory.Database;

namespace KSInventory.ViewModels
{
    [Preserve(AllMembers = true)]
    public class AddNewSaleViewModel : BaseViewModel
    {
        #region Private Variables

        private bool isSubmitButtonEnabled;
        private string quantitySold;
        private DateTime minimumDate;
        private DateTime maximumDate;
        private DateTime selectedDate;
        private ColorsVarity selectedColor;
        private DesignVarity selectedDesign;
        private SizeVarity selectedSize;
        private ProductDetails selectedProductDetail;
        private List<ColorsVarity> colorsVarities;
        private List<DesignVarity> designVarities;
        private List<SizeVarity> sizeVarities;
        private List<ProductDetails> productDetails;

        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        public AddNewSaleViewModel()
        {
            InitializeCommands();
            InitializeProperties();
        }

        #endregion

        #region Properties

        public bool IsSubmitButtonEnabled
        {
            get { return isSubmitButtonEnabled; }
            set
            {
                isSubmitButtonEnabled = value;
                OnPropertyChanged();
                ((Command)SaveCommand).ChangeCanExecute();
            }
        }
        public string QuantitySold
        {
            get {return quantitySold;}
            set { quantitySold = value; OnPropertyChanged(); }
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
        public ColorsVarity SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; OnPropertyChanged(); }
        }
        public DesignVarity SelectedDesign
        {
            get { return selectedDesign; }
            set { selectedDesign = value; OnPropertyChanged(); }
        }
        public SizeVarity SelectedSize
        {
            get { return selectedSize; }
            set { selectedSize = value; OnPropertyChanged(); }
        }
        public ProductDetails SelectedProductDetails
        {
            get { return selectedProductDetail; }
            set { selectedProductDetail = value; OnPropertyChanged(); }
        }
        public List<ColorsVarity> ColorsVarities
        {
            get { return colorsVarities; }
            set { colorsVarities = value; OnPropertyChanged(); }
        }
        public List<DesignVarity> DesignVarities
        {
            get { return designVarities; }
            set { designVarities = value; OnPropertyChanged(); }
        }
        public List<SizeVarity> SizeVarities
        {
            get { return sizeVarities; }
            set { sizeVarities = value; OnPropertyChanged(); }
        }
        public List<ProductDetails> ProductDetails
        {
            get { return productDetails; }
            set { productDetails = value; OnPropertyChanged(); }
        }
        public List<ProductDetails> OriginalProductDetails { get; set; }

        #endregion

        #region Methods

        private async void InitializeProperties()
        {
            IsSubmitButtonEnabled = false;
            MaximumDate = DateTime.Now;
            MinimumDate = new DateTime(2021,03,05);
            ColorsVarities = EnumGenerator.GetVarietyList(Variety.Colors).Cast<ColorsVarity>().ToList();
            DesignVarities = EnumGenerator.GetVarietyList(Variety.Designs).Cast<DesignVarity>().ToList();
            SizeVarities = EnumGenerator.GetVarietyList(Variety.Sizes).Cast<SizeVarity>().ToList();
            ProductDetails = await ProductRepository.GetAllProductDetails();
            OriginalProductDetails = await ProductRepository.GetAllProductDetails();
        }

        private void InitializeCommands()
        {
            SaveCommand = new Command(SaveSale,CanEnableSaveButton());
        }

        private Func<bool> CanEnableSaveButton()
        {
            return new Func<bool>(() => { return IsSubmitButtonEnabled; });
        }

        private async Task FilterProductsByColor()
        {
            if(SelectedColor != null)
            {
                if (SelectedColor.Colors == Colors.None)
                    return;
                ProductDetails = ProductDetails.Where(x => x.Color == SelectedColor.Colors).ToList();
            }
        }

        private async Task FilterProductsByDesign()
        {
            if (SelectedDesign != null)
            {
                if (SelectedDesign.Designs == Designs.None)
                    return;
                ProductDetails = ProductDetails.Where(x => x.Design == SelectedDesign.Designs).ToList();
            }
        }

        private async Task FilterProductsBySize()
        {
            if (SelectedSize != null)
            {
                if (SelectedSize.Sizes == Sizes.None)
                    return;
                ProductDetails = ProductDetails.Where(x => x.Size == SelectedSize.Sizes).ToList();
            }
        }

        public async void FilterProducts()
        {
            ProductDetails = OriginalProductDetails;
            await FilterProductsByColor();
            await FilterProductsByDesign();
            await FilterProductsBySize();
        }

        public void ShouldEnableSaveButton()
        {
            int soldQuantityCount = int.TryParse(QuantitySold, out int temp) ? temp : 0;
            if(SelectedProductDetails != null && soldQuantityCount >0)
            {
                IsSubmitButtonEnabled = true;
                return;
            }
            IsSubmitButtonEnabled = false;
        }

        private async void SaveSale()
        {
            try
            {
                IsBusy = true;
                ProductSalesDetails productSales = new ProductSalesDetails()
                {
                    Date = SelectedDate,
                    TotalSold = int.Parse(QuantitySold),
                    ProductId = SelectedProductDetails.Id
                };
                var isProductSaleAdded = await ProductSalesRepository.AddNewProductSale(productSales);
                IsBusy = false;
                if (isProductSaleAdded)
                {
                    await Application.Current.MainPage.DisplayAlert("Success!", "The sale has been updated.", "OK");
                    ClearAddStockForm();
                    //await Application.Current.MainPage.Navigation.PopAsync();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Alert!", "Something went wrong.", "Ok");
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

        private void ClearAddStockForm()
        {
            SelectedColor = new ColorsVarity();
            SelectedDesign = new DesignVarity();
            SelectedSize = new SizeVarity();
            SelectedProductDetails = new ProductDetails();
            SelectedDate = MinimumDate;
            QuantitySold = string.Empty;
        }

        #endregion
    }
}
