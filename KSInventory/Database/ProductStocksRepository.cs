using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSInventory.Database.Models;
using KSInventory.Helper;
using SQLiteNetExtensions.Extensions;

namespace KSInventory.Database
{
    public class ProductStocksRepository
    {
        // <summary>
        /// Get List of all Product Stocks Details.
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ProductStockDetails>> GetAllProductStocksDetails()
        {
            List<ProductStockDetails> productStocksDetails = null;
            using (var connection = SqliteExtension.GetConnection())
            {
                productStocksDetails = connection.GetAllWithChildren<ProductStockDetails>();
            }
            return productStocksDetails;
        }

        /// <summary>
        /// Add a new product stocks.
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        public async static Task<bool> AddNewProductStock(ProductStockDetails productStock)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                bool isDateExist = connection.GetAllWithChildren<ProductSalesDetails>().Where(x => x.ProductId == productStock.ProductId).Any(y => y.Date == productStock.Date);
                if (isDateExist)
                {
                    var isDateSaleEdited = await UpdateExistingProductStock(productStock);
                    return isDateSaleEdited;
                }
                else
                {
                    connection.Insert(productStock);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update an existing product stocks.
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        public async static Task<bool> UpdateProductStock(ProductStockDetails productStock)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                connection.Update(productStock);
                return true;
            }
            return false;
        }

        private async static Task<bool> UpdateExistingProductStock(ProductStockDetails productStock)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                var sales = connection.GetAllWithChildren<ProductStockDetails>().Where(x => x.ProductId == productStock.ProductId).ToList();
                var SameDateStock = sales.Where(x => x.Date == productStock.Date).ToList();
                if (SameDateStock.Count > 0)
                {
                    int totalDateSale = SameDateStock.Sum(x => x.StocksOrdered);
                    var stock = SameDateStock[0];
                    stock.StocksOrdered = totalDateSale + productStock.StocksOrdered;
                    connection.Update(stock);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Delete an existing product stocks.
        /// </summary>
        /// <param name="productStock"></param>
        /// <returns></returns>
        public async static Task<bool> DeleteProductStock(ProductStockDetails productStock)
        {
            using (var connection = SqliteExtension.GetConnection())
            {
                connection.Delete(productStock, recursive: true);
                return true;
            }
            return false;
        }
    }
}
