using System;
using System.Collections.Generic;
using KSInventory.Database.Models;
using KSInventory.ViewModels;
using Xamarin.Forms;

namespace KSInventory.Views
{
    public partial class ProductStockingPage : ContentPage
    {
        public ProductStockingPage(ProductDetails productDetails)
        {
            InitializeComponent();
            this.BindingContext = new ProductStockViewModel(productDetails);
        }
    }
}
