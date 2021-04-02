using System;
using System.Collections.Generic;
using KSInventory.Database.Models;
using KSInventory.Database.Models.Enums;

namespace KSInventory.Helper
{
    public class DummyDataGenerator
    {
        public DummyDataGenerator()
        {
        }

        public static List<ProductDetails> GetProductDetails()
        {
            List<ProductDetails> productDetails = new List<ProductDetails>()
            {
                // Red
                new ProductDetails()
                {
                    Id = 1,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Red,
                    Design = Designs.Solid,
                    Size = Sizes.Large,
                    ProductName = "Red T-Shirt Solid Large",
                    ProductSKU = "CTSRESOLL180",
                    TotalStockOrdered = 12,                    
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1).AddDays(-8),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 2,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 9
                        },
                        new ProductSalesDetails()
                        {
                            Id = 3,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-12),
                            TotalSold = 9
                        },
                        new ProductSalesDetails()
                        {
                            Id = 4,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1).AddDays(-15),
                            TotalSold = 14
                        },
                        new ProductSalesDetails()
                        {
                            Id = 5,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-4).AddDays(-8),
                            TotalSold = 15
                        },
                        new ProductSalesDetails()
                        {
                            Id = 6,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-3).AddDays(-12),
                            TotalSold = 20
                        },
                        new ProductSalesDetails()
                        {
                            Id = 7,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-7),
                            TotalSold = 18
                        },
                        new ProductSalesDetails()
                        {
                            Id = 8,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-5).AddDays(-5),
                            TotalSold = 14
                        },
                        new ProductSalesDetails()
                        {
                            Id = 9,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-8).AddDays(-6),
                            TotalSold = 7
                        },
                        new ProductSalesDetails()
                        {
                            Id = 10,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 11,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 12,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 13,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 2,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Red,
                    Design = Designs.LTA,
                    Size = Sizes.Medium,
                    ProductName = "Red T-Shirt LTA Medium",
                    ProductSKU = "CTSRELTAM180",
                    TotalStockOrdered = 10,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 14,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 15,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 16,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 17,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 18,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 3,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Red,
                    Design = Designs.NB,
                    Size = Sizes.XL,
                    ProductName = "Red T-Shirt NB XL",
                    ProductSKU = "CTSRENBXL180",
                    TotalStockOrdered = 6,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

                // Blue
                new ProductDetails()
                {
                    Id = 4,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Blue,
                    Design = Designs.Solid,
                    Size = Sizes.Small,
                    ProductName = "Blue T-Shirt Solid Small",
                    ProductSKU = "CTSBUSOLS180",
                    TotalStockOrdered = 12,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 5,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Blue,
                    Design = Designs.NB,
                    Size = Sizes.XXL,
                    ProductName = "Blue T-Shirt NB XXL",
                    ProductSKU = "CTSBUNBXXL180",
                    TotalStockOrdered = 10,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 6,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Blue,
                    Design = Designs.DA,
                    Size = Sizes.XL,
                    ProductName = "Blue T-Shirt DA XL",
                    ProductSKU = "CTSBUDAXL180",
                    TotalStockOrdered = 6,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

                // Black
                new ProductDetails()
                {
                    Id = 7,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Black,
                    Design = Designs.Solid,
                    Size = Sizes.Medium,
                    ProductName = "Black T-Shirt Solid Medium",
                    ProductSKU = "CTSBLSOLM180",
                    TotalStockOrdered = 12,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 8,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Black,
                    Design = Designs.NB,
                    Size = Sizes.XL,
                    ProductName = "Black T-Shirt NB XL",
                    ProductSKU = "CTSBLNBXL180",
                    TotalStockOrdered = 10,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 9,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Black,
                    Design = Designs.AR,
                    Size = Sizes.Large,
                    ProductName = "Black T-Shirt AR Large",
                    ProductSKU = "CTSBLARL180",
                    TotalStockOrdered = 6,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

                // Half White
                new ProductDetails()
                {
                    Id = 10,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.White,
                    Design = Designs.Solid,
                    Size = Sizes.Large,
                    ProductName = "Half-White T-Shirt Solid Large",
                    ProductSKU = "CTSHWSOLL180",
                    TotalStockOrdered = 12,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 11,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.White,
                    Design = Designs.LTA,
                    Size = Sizes.XL,
                    ProductName = "Half-White T-Shirt LTA XL",
                    ProductSKU = "CTSHWLTAXL180",
                    TotalStockOrdered = 10,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = 12,
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.White,
                    Design = Designs.AR,
                    Size = Sizes.Small,
                    ProductName = "Half-White T-Shirt AR Small",
                    ProductSKU = "CTSHWARS180",
                    TotalStockOrdered = 6,
                    SalesDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = 1,
                            ProductId = 1,
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

            };

            return productDetails;
        }
    }
}
