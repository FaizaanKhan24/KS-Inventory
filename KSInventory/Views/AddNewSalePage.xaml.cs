using System;
using System.Collections.Generic;
using KSInventory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class AddNewSalePage : ContentPage
    {
        public AddNewSalePage()
        {
            InitializeComponent();
            BindingContext = new AddNewSaleViewModel();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            datePicker.Focus();
        }

        void ColorPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if(this.BindingContext is AddNewSaleViewModel saleViewModel)
            {
                saleViewModel.FilterProducts();
            }
        }

        void DesignPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddNewSaleViewModel saleViewModel)
            {
                saleViewModel.FilterProducts();
            }
        }

        void SizePicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddNewSaleViewModel saleViewModel)
            {
                saleViewModel.FilterProducts();
            }
        }

        void ProductPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (this.BindingContext is AddNewSaleViewModel saleViewModel)
            {
                saleViewModel.ShouldEnableSaveButton();
            }
        }

        void datePicker_DateSelected(System.Object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            if (this.BindingContext is AddNewSaleViewModel saleViewModel)
            {
                saleViewModel.ShouldEnableSaveButton();
            }
        }

        void BorderlessEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (this.BindingContext is AddNewSaleViewModel saleViewModel)
            {
                saleViewModel.ShouldEnableSaveButton();
            }
        }
    }
}
