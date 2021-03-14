using System;
using System.Collections.Generic;
using KSInventory.Models;
using KSInventory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class EditProductPage : ContentPage
    {
        public EditProductPage(ProductDetails product)
        {
            InitializeComponent();
            this.BindingContext = new EditProductViewModel(product);
        }

        void BorderlessEntry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if(this.BindingContext is EditProductViewModel editProductViewModel)
            {
                editProductViewModel.ShouldEnableUpdateButton();
            }
        }
    }
}
