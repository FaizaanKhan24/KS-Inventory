using System;
using System.Collections.Generic;
using KSInventory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class ProductListPage : ContentPage
    {
        public List<Test> BindingTest { get; set; }

        public ProductListPage()
        {
            InitializeComponent();

            BindingTest = new List<Test>()
            {
                new Test()
                {
                    Color = Color.Blue,
                    Title = "BLUE",
                    DropDown = "W",
                    Texts = new List<string>()
                    {
                        "Small",
                        "Large",
                        "Medium",
                        "XL",
                        "XXL",
                        "Test-6",
                    }
                },
                new Test()
                {
                    Color = Color.Black,
                    Title = "BLACK",
                    DropDown = "X",
                    Texts = new List<string>()
                    {
                        "Small",
                        "Large",
                        "Medium",
                        "XL",
                        "XXL",
                        "Test-6",
                    }
                },
                new Test()
                {
                    Color = Color.Red,
                    Title = "RED",
                    DropDown = "Y",
                    Texts = new List<string>()
                    {
                        "Test-1",
                        "Test-2",
                        "Test-3",
                        "Test-4",
                        "Test-5",
                        "Test-6",
                    }
                },
                new Test()
                {
                    Color = Color.Beige,
                    Title = "HALF WHITE",
                    DropDown = "Z",
                    Texts = new List<string>()
                    {
                        "Test-1",
                        "Test-2",
                        "Test-3",
                        "Test-4",
                        "Test-5",
                        "Test-6",
                    }
                }

            };

            BindingContext = new ProductListViewModel();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(this.BindingContext is ProductListViewModel productListViewModel)
            {
                productListViewModel.SearchProduct();
            }
        }
    }

    public class Test
    {
        public Color Color { get; set; }
        public string Title { get; set; }
        public string DropDown { get; set; }
        public List<string> Texts { get; set; }
    }
}
