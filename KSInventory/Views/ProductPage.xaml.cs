using System;
using System.Collections.Generic;
using KSInventory.Models;
using KSInventory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class ProductPage : TabbedPage
    {
        public ProductPage(ProductDetails productDetails)
        {
            InitializeComponent();
            BindingContext = new ProductViewModel(productDetails);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send<object>(this, "InitializeGraph");  
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<object>(this, "InitializeGraph");
        }
    }
}
