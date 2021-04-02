using System;
using KSInventory.Database.Models.Enums;
using SQLite;

namespace KSInventory.Database.Models
{
    [Table("Colors Sales Details")]
    public class ColorDetails
    {
        [PrimaryKey, AutoIncrement]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Color")]
        public Colors Color { get; set; }

        [Column("Total Ordered")]
        public int TotalOrdered { get; set; }

        [Column("Safety Stock")]
        public int SafetyStock { get; set; }

        [Column("Stocks for Sale")]
        public int StockForSale { get; set; }

        [Column("Reordering Value")]
        public int ReorderingValue { get; set; }
    }
}
