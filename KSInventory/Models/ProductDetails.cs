using System;
using System.Collections.Generic;
using KSInventory.Models.Enums;

namespace KSInventory.Models
{
    public class ProductDetails
    {
        #region Private Variables

        #endregion

        #region Constructor

        public ProductDetails()
        {
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }
        public MaterialTypes Material { get; set; }
        public ProductTypes Product { get; set; }
        public Colors Color { get; set; }
        public Designs Design { get; set; }
        public Sizes Size { get; set; }
        public string ProductName { get; set; }
        public string ProductSKU { get; set; }
        public int TotalStockOrdered { get; set; }
        public int StockForSale
        {
            get { return GetStockForSale(TotalStockOrdered); }
        }
        public int SafetyStock
        {
            get { return GetSafetyStock(TotalStockOrdered); }
        }
        public int ReoredringValue
        {
            get { return GetReorderingValue(StockForSale); }
        }
        public int TotalStockSold
        {
            get { return GetTotalStocksSold(SaleDetails); }
        }
        public int AverageSold
        {
            get { return GetAverageStocksSold(SaleDetails); }
        }
        public int StockInHand
        {
            get { return GetStockInHand(TotalStockOrdered, TotalStockSold); }
        }
        public int NumberOfDays
        {
            get { return GetNumberOfDays(SaleDetails); }
        }

        public List<ProductSalesDetails> SaleDetails { get; set; }

        #endregion

        #region Methods

        private int GetSafetyStock(int totalStockOrdered)
        {
            int safetyStock = (int)(totalStockOrdered * 0.3);
            return safetyStock;
        }

        private int GetStockForSale(int totalStockOrdered)
        {
            int safetyStock = GetSafetyStock(totalStockOrdered);
            int stockForSale = totalStockOrdered - safetyStock;
            return stockForSale;
        }

        private int GetReorderingValue(int stockForSale)
        {
            int reorderingValue = (int)(0.4 * stockForSale);
            return reorderingValue;
        }

        private int GetTotalStocksSold(List<ProductSalesDetails> productSales)
        {
            int totalStockSold = 0;

            foreach (var saleDetail in productSales)
            {
                totalStockSold += saleDetail.TotalSold;
            }

            return totalStockSold;
        }

        private int GetAverageStocksSold(List<ProductSalesDetails> productSales)
        {
            int totalStockSold = GetTotalStocksSold(productSales);
            int numberOfDays = GetNumberOfDays(productSales);

            double averageSold = (double)totalStockSold / numberOfDays;
            int roundOffAverageStockSold = (int)Math.Ceiling(averageSold);

            return roundOffAverageStockSold;
        }

        private int GetStockInHand(int totalStockOrdered, int totalStockSold)
        {
            int stockInHand = totalStockOrdered - totalStockSold;
            return stockInHand;
        }

        private int GetNumberOfDays(List<ProductSalesDetails> productSales)
        {
            int numberOfDays = 0;
            if (productSales != null && productSales.Count > 0)
                numberOfDays = productSales.Count;
            return numberOfDays;
        }

        #endregion
    }
}
