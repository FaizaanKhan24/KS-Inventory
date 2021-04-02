using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace KSInventory.Database.Models
{
    public class FilteredProducts : INotifyPropertyChanged
    {
        #region Private variables

        private List<ProductDetails> categoryProducts;

        #endregion

        #region Properties

        public Color ProductCategoryColor { get; set; }
        public string ProductCategoryName { get; set; }
        public bool IsVisible { get; set; }
        public List<ProductDetails> CategoryProducts
        {
            get { return categoryProducts; }
            set
            {
                categoryProducts = value;
                SetProductColorVisiblity(value);
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void SetProductColorVisiblity(List<ProductDetails> categoryProduct)
        {
            if (categoryProduct != null && categoryProduct.Count > 0)
            {
                IsVisible = true;
                return;
            }
            IsVisible = false;
        }

        #endregion

        #region INotify Properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
