using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using KSInventory.Helper;
using KSInventory.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.ViewModels
{
    [Preserve(AllMembers = true)]
    public class AddProductViewModel : BaseViewModel
    {
        #region Private Variables

        private string productName;
        private string productSKU;
        private bool isSubmitButtonEnabled;
        private MaterialVarity  selectedMaterial;
        private ProductTypeVarity selectedProductType;
        private ColorsVarity selectedColor;
        private DesignVarity selectedDesign;
        private SizeVarity selectedSize;
        private List<MaterialVarity> materialVarities;
        private List<ProductTypeVarity> productTypeVarities;
        private List<ColorsVarity> colorsVarities;
        private List<DesignVarity> designVarities;
        private List<SizeVarity> sizeVarities;

        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        public AddProductViewModel(ProductDetails product = null)
        {
            InitializeCommands();
            InitializeProperties();
        }

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
        public MaterialVarity SelectedMaterial
        {
            get { return selectedMaterial; }
            set { selectedMaterial = value; OnPropertyChanged(); }
        }
        public ProductTypeVarity SelectedProductType
        {
            get { return selectedProductType; }
            set { selectedProductType = value; OnPropertyChanged(); }
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
        public List<MaterialVarity> MaterialVarities
        {
            get { return materialVarities; }
            set { materialVarities = value; OnPropertyChanged(); }
        }
        public List<ProductTypeVarity> ProductTypeVarities
        {
            get { return productTypeVarities; }
            set { productTypeVarities = value; OnPropertyChanged(); }
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

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            SaveCommand = new Command(SaveProduct,CanEnableSaveButton());
        }

        private void InitializeProperties()
        {
            IsSubmitButtonEnabled = false;
            MaterialVarities = EnumGenerator.GetVarietyList(Variety.MaterialType).Cast<MaterialVarity>().ToList();
            ProductTypeVarities = EnumGenerator.GetVarietyList(Variety.ProductType).Cast<ProductTypeVarity>().ToList();
            ColorsVarities = EnumGenerator.GetVarietyList(Variety.Colors).Cast<ColorsVarity>().ToList();
            DesignVarities = EnumGenerator.GetVarietyList(Variety.Designs).Cast<DesignVarity>().ToList();
            SizeVarities = EnumGenerator.GetVarietyList(Variety.Sizes).Cast<SizeVarity>().ToList();
        }

        private Func<bool> CanEnableSaveButton()
        {
            return new Func<bool>(() => { return IsSubmitButtonEnabled; });
        }

        public void ShouldEnableSubmitButton()
        {
            if (SelectedMaterial != null &&
                SelectedProductType != null &&
                SelectedDesign != null &&
                SelectedColor != null &&
                SelectedSize != null &&
                !string.IsNullOrEmpty(ProductName) &&
                !string.IsNullOrEmpty(ProductSKU))
            {
                IsSubmitButtonEnabled = true;
                return;
            }
            IsSubmitButtonEnabled = false;
        }           

        private async void SaveProduct()
        {
            await Application.Current.MainPage.DisplayAlert("Success!", "New Item has been successfully added :)", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
