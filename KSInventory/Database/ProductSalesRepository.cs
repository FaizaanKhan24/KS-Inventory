using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSInventory.Database.Models;
using KSInventory.Helper;
using SQLiteNetExtensions.Extensions;

namespace KSInventory.Database
{
    public class ProductSalesRepository
    {
        /// <summary>
        /// Get List of all Product Sale Details.
        /// </summary>
        /// <returns></returns>
        public async static Task<List<ProductSalesDetails>> GetAllProductSalesDetails()
        {
            List<ProductSalesDetails> productSalesDetails = null;
            using(var connection = SqliteExtension.GetConnection())
            {
                productSalesDetails = connection.GetAllWithChildren<ProductSalesDetails>();
            }
            return productSalesDetails;
        }

        /// <summary>
        /// Add a new product sale.
        /// </summary>
        /// <param name="productSales"></param>
        /// <returns></returns>
        public async static Task<bool> AddNewProductSale(ProductSalesDetails productSales)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                bool isDateExist = connection.GetAllWithChildren<ProductSalesDetails>().Where(x => x.ProductId == productSales.ProductId).Any(y => y.Date == productSales.Date);
                if (isDateExist)
                {
                    var isDateSaleEdited = await UpdateExistingProductSale(productSales);
                    return isDateSaleEdited;
                }
                else
                {
                    connection.Insert(productSales);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Update an existing product sale.
        /// </summary>
        /// <param name="productSales"></param>
        /// <returns></returns>
        public async static Task<bool> UpdateProductSale(ProductSalesDetails productSales)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                //bool isDateExist = connection.GetAllWithChildren<ProductSalesDetails>().Where(x => x.ProductId == productSales.ProductId).Any(y => y.Date == productSales.Date);
                //if (isDateExist)
                //{
                //    var isDateSaleEdited = await UpdateExistingProductSale(productSales);
                //    return isDateSaleEdited;
                //}
                connection.Update(productSales);
                return true;
            }
            return false;
        }

        private async static Task<bool> UpdateExistingProductSale(ProductSalesDetails productSales)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                var sales = connection.GetAllWithChildren<ProductSalesDetails>().Where(x => x.ProductId == productSales.ProductId).ToList();
                var SameDateSales = sales.Where(x => x.Date == productSales.Date).ToList();
                if (SameDateSales.Count > 0)
                {
                    int totalDateSale = SameDateSales.Sum(x => x.TotalSold);
                    var sale = SameDateSales[0];
                    sale.TotalSold = totalDateSale + productSales.TotalSold;
                    connection.Update(sale);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Delete an existing product sale.
        /// </summary>
        /// <param name="productSales"></param>
        /// <returns></returns>
        public async static Task<bool> DeleteProductSale(ProductSalesDetails productSales)
        {
            using(var connection = SqliteExtension.GetConnection())
            {
                connection.Delete(productSales, recursive: true);
                return true;
            }
            return false;
        }
    }
}
