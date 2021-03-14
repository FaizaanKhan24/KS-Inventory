using System;
using System.Collections.Generic;
using KSInventory.Models;
using KSInventory.Models.Enums;

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
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Red,
                    Design = Designs.Solid,
                    Size = Sizes.Large,
                    ProductName = "Red T-Shirt Solid Large",
                    ProductSKU = "CTSRESOLL180",
                    TotalStockOrdered = 12,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1).AddDays(-8),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 9
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-12),
                            TotalSold = 9
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1).AddDays(-15),
                            TotalSold = 14
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-4).AddDays(-8),
                            TotalSold = 15
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-3).AddDays(-12),
                            TotalSold = 20
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-7),
                            TotalSold = 18
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-5).AddDays(-5),
                            TotalSold = 14
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-8).AddDays(-6),
                            TotalSold = 7
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Red,
                    Design = Designs.LTA,
                    Size = Sizes.Medium,
                    ProductName = "Red T-Shirt LTA Medium",
                    ProductSKU = "CTSRELTAM180",
                    TotalStockOrdered = 10,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Red,
                    Design = Designs.NB,
                    Size = Sizes.XL,
                    ProductName = "Red T-Shirt NB XL",
                    ProductSKU = "CTSRENBXL180",
                    TotalStockOrdered = 6,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

                // Blue
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Blue,
                    Design = Designs.Solid,
                    Size = Sizes.Small,
                    ProductName = "Blue T-Shirt Solid Small",
                    ProductSKU = "CTSBUSOLS180",
                    TotalStockOrdered = 12,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Blue,
                    Design = Designs.NB,
                    Size = Sizes.XXL,
                    ProductName = "Blue T-Shirt NB XXL",
                    ProductSKU = "CTSBUNBXXL180",
                    TotalStockOrdered = 10,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Blue,
                    Design = Designs.DA,
                    Size = Sizes.XL,
                    ProductName = "Blue T-Shirt DA XL",
                    ProductSKU = "CTSBUDAXL180",
                    TotalStockOrdered = 6,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

                // Black
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Black,
                    Design = Designs.Solid,
                    Size = Sizes.Medium,
                    ProductName = "Black T-Shirt Solid Medium",
                    ProductSKU = "CTSBLSOLM180",
                    TotalStockOrdered = 12,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Black,
                    Design = Designs.NB,
                    Size = Sizes.XL,
                    ProductName = "Black T-Shirt NB XL",
                    ProductSKU = "CTSBLNBXL180",
                    TotalStockOrdered = 10,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.Black,
                    Design = Designs.AR,
                    Size = Sizes.Large,
                    ProductName = "Black T-Shirt AR Large",
                    ProductSKU = "CTSBLARL180",
                    TotalStockOrdered = 6,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },

                // Half White
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.White,
                    Design = Designs.Solid,
                    Size = Sizes.Large,
                    ProductName = "Half-White T-Shirt Solid Large",
                    ProductSKU = "CTSHWSOLL180",
                    TotalStockOrdered = 12,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.White,
                    Design = Designs.LTA,
                    Size = Sizes.XL,
                    ProductName = "Half-White T-Shirt LTA XL",
                    ProductSKU = "CTSHWLTAXL180",
                    TotalStockOrdered = 10,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-1),
                            TotalSold = 9
                        }
                    }
                },
                new ProductDetails()
                {
                    Id = Guid.NewGuid(),
                    Material = MaterialTypes.Cotton180GSMBiowash,
                    Product = ProductTypes.TShirt,
                    Color = Colors.White,
                    Design = Designs.AR,
                    Size = Sizes.Small,
                    ProductName = "Half-White T-Shirt AR Small",
                    ProductSKU = "CTSHWARS180",
                    TotalStockOrdered = 6,
                    SaleDetails = new List<ProductSalesDetails>()
                    {
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddMonths(-1),
                            TotalSold = 4
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-7),
                            TotalSold = 6
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Now,
                            TotalSold = 1
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Date = DateTime.Today.AddDays(-3),
                            TotalSold = 3
                        },
                        new ProductSalesDetails()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
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
