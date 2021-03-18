using System.Collections.Generic;
using Sales_Tax.Models;

namespace Sales_Tax_Tests.TestData
{
    public class ItemTestData
    {
        public static Item BookItem =>
            new Item
            {
                Price = 12.49,
                Name = "Book",
                CategoryTax = new CategoryTax{TaxableItemCategories = new List<TaxableItemCategory>{}}
            };
        public static Item MusicCdItem =>
            new Item
            {
                Price = 14.99,
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
        public static Item ChocolateBarItem =>
            new Item
            {
                Price = 0.85,
                Name = "Chocolate bar"
            };
        public static Item ImportedBoxOfChocolatesItem =>
            new Item
            {
                Price = 10,
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
                Price = 47.50,
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
        public static Item ImportedBottleOfPerfumeNo2Item =>
            new Item
            {
                Price = 27.99,
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
        public static Item BottleOfPerfumeItem =>
            new Item
            {
                Price = 18.99,
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
        public static Item BottleOfParacetamolItem =>
            new Item
            {
                Price = 9.75,
                Name = "Bottle of paracetamol"
            };
        public static Item BoxOfChocolates2Item =>
            new Item
            {
                Price = 11.25,
                Name = "Box of chocolates"
            };

    }
}
