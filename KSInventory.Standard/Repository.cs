using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSInventory.Database.Models;

namespace KSInventory.Database
{
    public class Repository 
    {
        private DatabaseContext GetDatabaseContext()
        {
            return new DatabaseContext();
        }

        #region Product

        public Task<List<ProductDetails>> GetProductsAsync()
        {
            using(var context = GetDatabaseContext())
            {
                List<ProductDetails> productDetails = context.ProductDetails.ToList();
                return Task.FromResult(productDetails);
            }
        }
        public Task<bool> AddNewProduct(ProductDetails product)
        {
            using(var context = GetDatabaseContext())
            {
                bool isProductExist = context.ProductDetails.Any(x => x.ProductSKU == product.ProductSKU);
                if (isProductExist)
                {
                    context.ProductDetails.Add(product);
                    context.SaveChanges();
                    return Task.FromResult(true);
                }
                else
                    return Task.FromResult(false);
            }
        }
        //public Task<bool> UpdateProductDetails(ProductDetails product)
        //{
            
        //}
        public Task<bool> DeleteProduct(ProductDetails product)
        {
            using(var context = GetDatabaseContext())
            {
                bool isProductExist = context.ProductDetails.Any(x => x.ProductSKU == product.ProductSKU);
                if (isProductExist)
                {
                    var selectedProduct = context.ProductDetails.Where(x => x.ProductSKU == product.ProductSKU).FirstOrDefault();
                    context.ProductDetails.Remove(selectedProduct);
                    context.SaveChanges();
                    return Task.FromResult(true);
                }
                else
                    return Task.FromResult(false);
            }
        }

        #endregion

        #region Product Sales

        #endregion

        #region Color

        #endregion
    }
}
