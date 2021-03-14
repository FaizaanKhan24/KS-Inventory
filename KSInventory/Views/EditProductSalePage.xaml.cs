using System;
using System.Collections.Generic;
using KSInventory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class EditProductSalePage : ContentPage
    {
        public EditProductSalePage(ProductViewModel productViewModel)
        {
            InitializeComponent();
            this.BindingContext = productViewModel;
        }

        void quantitySold_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if(this.BindingContext is ProductViewModel productViewModel)
            {
                productViewModel.ShouldEnableUpdateButton();
            }
        }

        void selectDateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            datePicker.Focus();
        }
    }
}
