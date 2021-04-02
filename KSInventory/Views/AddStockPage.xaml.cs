using System;
using System.Collections.Generic;
using KSInventory.ViewModels;
using Xamarin.Forms;

namespace KSInventory.Views
{
    public partial class AddStockPage : ContentPage
    {
        public AddStockPage()
        {
            InitializeComponent();
            this.BindingContext = new AddStockViewModel();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            datePicker.Focus();
        }

        void ColorPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddStockViewModel stockViewModel)
            {
                stockViewModel.FilterProducts();
            }
        }

        void DesignPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddStockViewModel stockViewModel)
            {
                stockViewModel.FilterProducts();
            }
        }

        void SizePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddStockViewModel stockViewModel)
            {
                stockViewModel.FilterProducts();
            }
        }

        void ProductPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddStockViewModel stockViewModel)
            {
                stockViewModel.ShouldEnableSaveButton();
            }
        }

        void datePicker_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            if (this.BindingContext is AddStockViewModel stockViewModel)
            {
                stockViewModel.ShouldEnableSaveButton();
            }
        }

        void BorderlessEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (this.BindingContext is AddStockViewModel stockViewModel)
            {
                stockViewModel.ShouldEnableSaveButton();
            }
        }
    }
}
