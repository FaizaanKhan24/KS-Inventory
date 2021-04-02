using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using KSInventory.Database.Models.Enums;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace KSInventory.Database.Models
{
    [Table("Product Details")]
    public class ProductDetails : INotifyPropertyChanged
    {
        #region Private Variables

        private List<ProductStockDetails> stockDetails;

        #endregion

        #region Properties

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

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
            get { return GetTotalStocksSold(SalesDetails); }
        }
        public int AverageSold
        {
            get { return GetAverageStocksSold(SalesDetails); }
        }
        public int StockInHand
        {
            get { return GetStockInHand(TotalStockOrdered, TotalStockSold); }
        }
        public int NumberOfDays
        {
            get { return GetNumberOfDays(SalesDetails); }
        }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ProductSalesDetails> SalesDetails { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ProductStockDetails> StockDetails
        {
            get { return stockDetails; }
            set
            {
                stockDetails = value;
                SetTotalStockOrdered(value);
                OnPropertyChanged();
            }
        }

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

        private void SetTotalStockOrdered(List<ProductStockDetails> productStockDetails)
        {
            if (productStockDetails != null && productStockDetails.Count > 0)
            {
                TotalStockOrdered = 0;
                foreach (var stockDetails in productStockDetails)
                {
                    TotalStockOrdered += stockDetails.StocksOrdered;
                }
            }
            else
                TotalStockOrdered = 0;
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
