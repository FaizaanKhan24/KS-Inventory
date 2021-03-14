using System;
using System.Collections.Generic;
using System.Linq;
using KSInventory.Models.Enums;

namespace KSInventory.Helper
{
    public class EnumGenerator
    {
        public EnumGenerator()
        {
        }

        public static List<object> GetVarietyList(Variety variety)
        {
            switch (variety)
            {
                case Variety.MaterialType:
                    {
                        List<MaterialVarity> materialVarities = new List<MaterialVarity>();
                        foreach (MaterialTypes materialTypes in Enum.GetValues(typeof(MaterialTypes)))
                        {
                            materialVarities.Add(new MaterialVarity() { MaterialTypes = materialTypes });
                        }
                        return materialVarities.Cast<object>().ToList();
                    }
                case Variety.ProductType:
                    {
                        List<ProductTypeVarity> productTypeVarities = new List<ProductTypeVarity>();
                        foreach (ProductTypes productTypes in Enum.GetValues(typeof(ProductTypes)))
                        {
                            productTypeVarities.Add(new ProductTypeVarity() { ProductTypes = productTypes });
                        }
                        return productTypeVarities.Cast<object>().ToList();
                    }
                case Variety.Colors:
                    {
                        List<ColorsVarity> colorsVarities = new List<ColorsVarity>();
                        foreach (Colors colors in Enum.GetValues(typeof(Colors)))
                        {
                            colorsVarities.Add(new ColorsVarity() { Colors = colors });
                        }
                        return colorsVarities.Cast<object>().ToList();
                    }
                case Variety.Designs:
                    {
                        List<DesignVarity> designVarities = new List<DesignVarity>();
                        foreach (Designs designs in Enum.GetValues(typeof(Designs)))
                        {
                            designVarities.Add(new DesignVarity() { Designs = designs });
                        }
                        return designVarities.Cast<object>().ToList();
                    }
                case Variety.Sizes:
                    {
                        List<SizeVarity> sizeVarities = new List<SizeVarity>();
                        foreach (Sizes sizes in Enum.GetValues(typeof(Sizes)))
                        {
                            sizeVarities.Add(new SizeVarity() { Sizes = sizes });
                        }
                        return sizeVarities.Cast<object>().ToList();
                    }

                default: return null;
            }
        }
    }

    public class MaterialVarity
    {
        public MaterialTypes MaterialTypes { get; set; }
    }
    public class ProductTypeVarity
    {
        public ProductTypes ProductTypes { get; set; }
    }
    public class ColorsVarity
    {
        public Colors Colors { get; set; }
    }
    public class DesignVarity
    {
        public Designs Designs { get; set; }
    }
    public class SizeVarity
    {
        public Sizes Sizes { get; set; }
    }
    public enum Variety
    {
        MaterialType,
        ProductType,
        Colors,
        Designs,
        Sizes
    }
}
