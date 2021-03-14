using System.Collections.Generic;
using System.Threading.Tasks;
using KSInventory.Database.Models;
using KSInventory.Database.Models.Enums;

namespace KSInventory.Database
{
    public interface IRepository
    {
        #region Product

        public Task<List<ProductDetails>> GetProductsAsync();
        public Task<bool> AddNewProduct(ProductDetails product);
        public Task<bool> UpdateProductDetails(ProductDetails product);
        public Task<bool> DeleteProduct(ProductDetails product);

        #endregion

        #region Product Sales

        public Task<bool> AddNewProductSalesDetails(ProductSalesDetails productSales);
        public Task<bool> UpdateProductSalesDetails(ProductSalesDetails productSales);
        public Task<bool> DeleteProductSale(ProductSalesDetails productSales);

        #endregion

        #region Color

        public Task<List<ColorDetails>> GetColorDetails();
        public Task<bool> SaveOrUpdateColorDetails(Colors color, ProductDetails product);

        #endregion
    }
}