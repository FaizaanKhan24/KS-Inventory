using System;

namespace KSInventory.Models
{
    public class ProductSalesDetails
    {
        public ProductSalesDetails()
        {
            Date = DateTime.Today;
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public DateTime Date { get; set; }
        public int TotalSold { get; set; }
    }
}
