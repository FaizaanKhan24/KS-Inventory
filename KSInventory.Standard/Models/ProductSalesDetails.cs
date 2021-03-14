using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSInventory.Database.Models
{
    [Table("Product Sale Details")]
    public class ProductSalesDetails
    {
        [Key]
        public Guid Id { get; set; }
        public virtual ProductDetails ProductId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSold { get; set; }
    }
}
