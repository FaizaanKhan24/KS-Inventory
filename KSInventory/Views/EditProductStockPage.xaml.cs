using System;
using System.Collections.Generic;
using KSInventory.ViewModels;
using Xamarin.Forms;

namespace KSInventory.Views
{
    public partial class EditProductStockPage : ContentPage
    {
        public EditProductStockPage(ProductStockViewModel productStockViewModel)
        {
            InitializeComponent();
            this.BindingContext = productStockViewModel;
        }

        void stockQuantity_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (this.BindingContext is ProductStockViewModel productStockViewModel)
            {
                productStockViewModel.ShouldEnableUpdateButton();
            }
        }

        void selectDateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            datePicker.Focus();
        }
    }
}
