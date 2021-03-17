//using System;
//using System.Threading.Tasks;
//using Sales_Tax.Logic;
//using Sales_Tax.Models;
//using Xunit;

//namespace Sales_Tax_Tests
//{
//    public class SalesTaxManagerTests
//    {
//        [Fact]
//        public void CalculateSalesTaxPerItemTrueNoTax()
//        {
//            var item = new Item()
//            {
//                Quantity = 1,
//                Price = 12.49,
//                Name = "Book"
//            };

//            var itemCategory = new ItemCategory()
//            {
//                CategoryName = "Book",
//                CategoryTaxRate = 0
//            };

//            var manager = new SalesTaxManager();
//            double interestOnProduct =  manager.CalculateSalesTaxPerItem(itemCategory, item);
//            double itemFinalPriceWithTax = Math.Round(interestOnProduct + item.Price, 2) * item.Quantity;

//            Assert.Equal(0, interestOnProduct);
//            Assert.Equal(12.49, itemFinalPriceWithTax);
//        }

//        [Fact]
//        public void CalculateSalesTaxPerItemTrueTax()
//        {
//            var item = new Item()
//            {
//                Quantity = 1,
//                Price = 14.99,
//                Name = "Music CD"
//            };

//            var itemCategory = new ItemCategory()
//            {
//                CategoryName = "All",
//                CategoryTaxRate = 10
//            };

//            var manager = new SalesTaxManager();
//            double interestOnProduct = manager.CalculateSalesTaxPerItem(itemCategory, item);
//            double itemFinalPriceWithTax = Math.Round(interestOnProduct + item.Price, 2) * item.Quantity;

//            Assert.Equal(1.499, interestOnProduct);
//            Assert.Equal(16.49, itemFinalPriceWithTax);
//        }

//        [Fact]
//        public void CalculateSalesImportTaxPerItemTrue()
//        {
//            var item = new Item()
//            {
//                Quantity = 1,
//                Price = 47.50,
//                Name = "Imported bottle of perfume"
//            };

//            var itemCategory = new ItemCategory()
//            {
//                CategoryName = "All",
//                CategoryTaxRate = 10
//            };

//            var manager = new SalesTaxManager();
//            double interestOnProduct = manager.CalculateSalesTaxPerItem(itemCategory, item);
//            double itemFinalPriceWithTax = Math.Round(interestOnProduct + item.Price, 2) * item.Quantity;

//            Assert.Equal(1.499, interestOnProduct);
//            Assert.Equal(16.49, itemFinalPriceWithTax);
//        }
//    }
//}
