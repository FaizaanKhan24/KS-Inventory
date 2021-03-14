using System;
using KSInventory.Models.Enums;

namespace KSInventory.Models
{
    public class ColorDetails
    {
        public Guid Id { get; set; }
        public Colors Color { get; set; }
        public int TotalOrdered { get; set; }
        public int SafetyStock { get; set; }
        public int StockForSale { get; set; }
        public int ReorderingValue { get; set; }
    }
}
