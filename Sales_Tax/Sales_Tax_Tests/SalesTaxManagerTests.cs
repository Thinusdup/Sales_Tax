using System;
using System.ComponentModel;
using Sales_Tax.Logic;
using Sales_Tax.Models;
using Sales_Tax_Tests.TestData;
using Xunit;

namespace Sales_Tax_Tests
{
    public class SalesTaxManagerTests
    {
        [Fact]
        public void CalculateSalesTaxForBookItem()
        {
            double interestOnProduct = 0;
            var itemTestData = ItemTestData.BookItem;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData);
                }
            }
            var basket = new Basket();
            basket.Quantity = 1;
         
            double itemFinalPriceWithTax = Math.Round(interestOnProduct + itemTestData.Price, 2) * basket.Quantity;

            Assert.Equal(0, interestOnProduct);
            Assert.Equal(12.49, itemFinalPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForMusicItem()
        {
            double interestOnProduct = 0;
            var itemTestData = ItemTestData.MusicCdItem;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData);
                }
            }
            var basket = new Basket();
            basket.Quantity = 1;

            double itemFinalPriceWithTax = Math.Round(interestOnProduct + itemTestData.Price, 2) * basket.Quantity;

            Assert.Equal(1.499, interestOnProduct);
            Assert.Equal(16.49, itemFinalPriceWithTax);
        }

        //[Fact]
        //public void CalculateSalesImportTaxPerItemTrue()
        //{
        //    var item = new Item()
        //    {
        //        Quantity = 1,
        //        Price = 47.50,
        //        Name = "Imported bottle of perfume"
        //    };

        //    var itemCategory = new ItemCategory()
        //    {
        //        CategoryName = "All",
        //        CategoryTaxRate = 10
        //    };

        //    var manager = new SalesTaxManager();
        //    double interestOnProduct = manager.CalculateSalesTaxPerItem(itemCategory, item);
        //    double itemFinalPriceWithTax = Math.Round(interestOnProduct + item.Price, 2) * item.Quantity;

        //    Assert.Equal(1.499, interestOnProduct);
        //    Assert.Equal(16.49, itemFinalPriceWithTax);
        //}
    }
}
