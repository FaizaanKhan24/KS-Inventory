using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KSInventory.Database.Models.Enums;

namespace KSInventory.Database.Models
{
    [Table("Product Details")]
    public class ProductDetails
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("Material Type")]
        public MaterialTypes Material { get; set; }
        [Column("Product Type")]
        public ProductTypes Product { get; set; }
        [Column("Color")]
        public Colors Color { get; set; }
        [Column("Design")]
        public Designs Design { get; set; }
        [Column("Size")]
        public Sizes Size { get; set; }
        [Column("Name")]
        public string ProductName { get; set; }
        [Column("Product SKU")]
        public string ProductSKU { get; set; }
        [Column("Total Stock Ordered")]
        public int TotalStockOrdered { get; set; }
        //[Column("Stocks for Sale")]
        //public int StockForSale { get; set; }
        //[Column("Safety Stocks")]
        //public int SafetyStock { get; set; }
        //[Column("Reordering Value")]
        //public int ReoredringValue { get; set; }
        //[Column("Total Stocks Sold")]
        //public int TotalStockSold { get; set; }
        //[Column("Average Stocks Sold")]
        //public int AverageSold { get; set; }
        //[Column("Stocks in Hand")]
        //public int StockInHand { get; set; }
        //[Column("Number of Days")]
        //public int NumberOfDays { get; set; }

        [ForeignKey("ProductId")]
        public virtual List<ProductSalesDetails> SalesDetails { get; set; }
    }
}
