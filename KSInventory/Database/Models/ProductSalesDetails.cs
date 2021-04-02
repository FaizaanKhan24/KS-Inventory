using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace KSInventory.Database.Models
{
    [Table("Product Sale Details")]
    public class ProductSalesDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(ProductDetails))]
        public int ProductId { get; set; }

        public DateTime Date { get; set; }

        public int TotalSold { get; set; }
    }
}
