using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KSInventory.Database.Models.Enums;

namespace KSInventory.Database.Models
{
    [Table("Colors Sales Details")]
    public class ColorDetails
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }
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
