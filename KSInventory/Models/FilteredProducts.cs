using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KSInventory.Models
{
    public class FilteredProducts
    {
        public Color ProductCategoryColor { get; set; }
        public string ProductCategoryName { get; set; }
        public List<ProductDetails> CategoryProducts { get; set; }
    }
}
