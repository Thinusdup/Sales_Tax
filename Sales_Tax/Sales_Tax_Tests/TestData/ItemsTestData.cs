using System.Collections.Generic;
using Sales_Tax.Common.Models;

namespace Sales_Tax_Tests.TestData
{
    public class ItemTestData
    {
        //Input 1
        public static Item Book =>
            new Item
            {
                Quantity = 1,
                Price = 12.49M,
                Name = "Book",
                CategoryTax = new CategoryTax{TaxableItemCategories = new List<TaxableItemCategory>{}}
            };
        public static Item MusicCd =>
            new Item
            {
                Quantity = 1,
                Price = 14.99M,
                Name = "Music CD",
                CategoryTax = new CategoryTax
                {
                    TaxableItemCategories = new List<TaxableItemCategory>
                    {
                        new TaxableItemCategory
                        {
                            CategoryName = "All", CategoryTaxRate = 10
                        }
                    }
                }
            };
        public static Item ChocolateBar =>
            new Item
            {
                Quantity = 1,
                Price = 0.85M,
                Name = "Chocolate bar",
                CategoryTax = new CategoryTax { TaxableItemCategories = new List<TaxableItemCategory> { } }
            };

        //Input 2
        public static Item ImportedBoxOfChocolates =>
            new Item
            {
                Quantity = 1,
                Price = 10M,
                Name = "Imported Box of chocolates",
                CategoryTax = new CategoryTax
                {
                    TaxableItemCategories = new List<TaxableItemCategory>
                    {
                        new TaxableItemCategory
                        {
                            CategoryName = "Imported", CategoryTaxRate = 5
                        }
                    }
                }
            };
        public static Item ImportedBottleOfPerfume =>
            new Item
            {
                Quantity = 1,
                Price = 47.50M,
                Name = "Imported Bottle of perfume",
                CategoryTax = new CategoryTax
                {
                    TaxableItemCategories = new List<TaxableItemCategory>
                    {
                        new TaxableItemCategory
                        {
                            CategoryName = "All", CategoryTaxRate = 10
                        },
                        new TaxableItemCategory
                        {
                            CategoryName = "Imported", CategoryTaxRate = 5
                        }
                    }
                }
            };

        //Input 3
        public static Item ImportedBottleOfPerfumeNo2 =>
            new Item
            {
                Quantity = 1,
                Price = 27.99M,
                Name = "Imported Bottle of perfume",
                CategoryTax = new CategoryTax
                {
                    TaxableItemCategories = new List<TaxableItemCategory>
                    {
                        new TaxableItemCategory
                        {
                            CategoryName = "All", CategoryTaxRate = 10
                        },
                        new TaxableItemCategory
                        {
                            CategoryName = "Imported", CategoryTaxRate = 5
                        }
                    }
                }
            };
        public static Item BottleOfPerfume =>
            new Item
            {
                Quantity = 1,
                Price = 18.99M,
                Name = "Bottle of perfume",
                CategoryTax = new CategoryTax
                {
                    TaxableItemCategories = new List<TaxableItemCategory>
                    {
                        new TaxableItemCategory
                        {
                            CategoryName = "All", CategoryTaxRate = 10
                        }
                    }
                }
            };
        public static Item BottleOfParacetamol =>
            new Item
            {
                Quantity = 1,
                Price = 9.75M,
                Name = "Bottle of paracetamol",
                CategoryTax = new CategoryTax { TaxableItemCategories = new List<TaxableItemCategory> { } }
            };
        public static Item ImportedBoxOfChocolates2Item =>
            new Item
            {
                Quantity = 1,
                Price = 11.25M,
                Name = "Box of chocolates",
                CategoryTax = new CategoryTax
                {
                    TaxableItemCategories = new List<TaxableItemCategory>
                    {
                        new TaxableItemCategory
                        {
                            CategoryName = "Imported", CategoryTaxRate = 5
                        }
                    }
                }
            };

    }
}
