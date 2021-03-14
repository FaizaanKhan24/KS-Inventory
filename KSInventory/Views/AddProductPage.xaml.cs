using KSInventory.Models;
using KSInventory.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KSInventory.Views
{
    [Preserve(AllMembers = true)]
    public partial class AddProductPage : ContentPage
    {
        public AddProductPage(ProductDetails product = null)
        {
            InitializeComponent();
            BindingContext = new AddProductViewModel(product);
        }

        void Picker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if(this.BindingContext is AddProductViewModel addProductViewModel)
            {
                addProductViewModel.ShouldEnableSubmitButton();
            }
        }

        void Entry_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (this.BindingContext is AddProductViewModel addProductViewModel)
            {
                addProductViewModel.ShouldEnableSubmitButton();
            }
        }

        void BorderlessPicker_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (this.BindingContext is AddProductViewModel addProductViewModel)
            {
                addProductViewModel.ShouldEnableSubmitButton();
            }
        }
    }
}
