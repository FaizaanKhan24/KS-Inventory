using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using KSInventory.Helper;
using KSInventory.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

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

        private void InitializeProperties()
        {
            IsSubmitButtonEnabled = false;
            MaximumDate = DateTime.Now;
            MinimumDate = new DateTime(2021,01,01);
            ColorsVarities = EnumGenerator.GetVarietyList(Variety.Colors).Cast<ColorsVarity>().ToList();
            DesignVarities = EnumGenerator.GetVarietyList(Variety.Designs).Cast<DesignVarity>().ToList();
            SizeVarities = EnumGenerator.GetVarietyList(Variety.Sizes).Cast<SizeVarity>().ToList();
            ProductDetails = DummyDataGenerator.GetProductDetails();
            OriginalProductDetails = DummyDataGenerator.GetProductDetails();
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
                if (SelectedColor.Colors == Models.Enums.Colors.None)
                    return;
                ProductDetails = ProductDetails.Where(x => x.Color == SelectedColor.Colors).ToList();
            }
        }

        private async Task FilterProductsByDesign()
        {
            if (SelectedDesign != null)
            {
                if (SelectedDesign.Designs == Models.Enums.Designs.None)
                    return;
                ProductDetails = ProductDetails.Where(x => x.Design == SelectedDesign.Designs).ToList();
            }
        }

        private async Task FilterProductsBySize()
        {
            if (SelectedSize != null)
            {
                if (SelectedSize.Sizes == Models.Enums.Sizes.None)
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
            await Application.Current.MainPage.DisplayAlert("Success!", "The sale has been updated.", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
