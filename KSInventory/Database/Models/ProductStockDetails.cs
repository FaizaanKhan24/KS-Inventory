using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace KSInventory.Database.Models
{
    [Table("Product Stock Details")]
    public class ProductStockDetails
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(ProductDetails))]
        public int ProductId { get; set; }

        public DateTime Date { get; set; }        

        public int StocksOrdered { get; set; }
    }
}
