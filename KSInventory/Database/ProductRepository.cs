using System.Collections.Generic;
using System.Threading.Tasks;
using KSInventory.Database.Models;
using KSInventory.Helper;
using SQLiteNetExtensions.Extensions;

namespace KSInventory.Database
{
    public class ProductRepository
    {
        /// <summary>
        /// Get List of Prioduct Details.
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ProductDetails>> GetAllProductDetails()
        {
            List<ProductDetails> productDetails = null;
            using(var connection = SqliteExtension.GetConnection())
            {
                productDetails = connection.GetAllWithChildren<ProductDetails>();
            }
            return productDetails;
        }

        /// <summary>
        /// Add a new product along with it's children.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async static Task<bool> AddNewProduct(ProductDetails product)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                connection.InsertWithChildren(product);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update the given product details.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async static Task<bool> UpdateProduct(ProductDetails product)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                connection.Update(product);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete the given product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async static Task<bool> DeleteProduct(ProductDetails product)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                connection.Delete(product, recursive: true);
                return true;
            }
            return false;
        }
    }
}
