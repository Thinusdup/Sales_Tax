using Sales_Tax.Logic;
using Sales_Tax.Common.Models;
using Sales_Tax.Data;
using Xunit;

namespace Sales_Tax_Tests
{
    public class SalesTaxManagerTests
    {

        //Input 1
        [Fact]
        public void CalculateSalesTaxForBookItem()
        {
            decimal salesTaxOnProduct = 0;

            var itemTestData = ItemTestData.Book;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }

            var finalItemPriceWithTax = itemTestData.Price;

            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }
            Assert.Equal(0, salesTaxOnProduct);
            Assert.Equal(12.49M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForMusicItem()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.MusicCd;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(1.5M, salesTaxOnProduct);
            Assert.Equal(16.49M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForChocolateBarItem()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.ChocolateBar;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(0M, salesTaxOnProduct);
            Assert.Equal(0.85M, finalItemPriceWithTax);
        }

        [Fact]
        public static void CalculateBasketInput1Results()
        {
            var manager = new SalesTaxManager();

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;

            foreach (var basketItem in BasketTestData.BuildInputOneBasket.Items)
            {
                decimal salesTaxPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        salesTaxPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem.Price);
                    }
                }
                var finalItemPriceWithTax = basketItem.Price;

                var salesTax = new SalesTax
                {
                    SalesTaxCalculated = salesTaxPerProduct,
                    ItemPrice = basketItem.Price
                };
             
                if (salesTaxPerProduct != 0)
                {
                    finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
                }

                basketTotalTax += salesTaxPerProduct;
                basketTotalPrice += finalItemPriceWithTax;
            }
            
            Assert.Equal(1.50M, basketTotalTax);
            Assert.Equal(29.83M, basketTotalPrice);
        }

        //Input 2
        [Fact]
        public void CalculateSalesTaxForImportedBottleOfImportedBoxOfChocolatesItem()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBoxOfChocolates;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }

            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(0.50M, salesTaxOnProduct);
            Assert.Equal(10.50M, finalItemPriceWithTax);
        }
        [Fact]
        public void CalculateSalesTaxForImportedBottleOfPerfumeItem()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBottleOfPerfume;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }

            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(7.15M, salesTaxOnProduct);
            Assert.Equal(54.65M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateBasketInput2Results()
        {
            var manager = new SalesTaxManager();

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;

            foreach (var basketItem in BasketTestData.BuildInputTwoBasket.Items)
            {
                decimal salesTaxPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        salesTaxPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem.Price);
                    }
                }
                var finalItemPriceWithTax = basketItem.Price;
                var salesTax = new SalesTax
                {
                    SalesTaxCalculated = salesTaxPerProduct,
                    ItemPrice = basketItem.Price
                };

                if (salesTaxPerProduct != 0)
                {
                    finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
                }


                basketTotalTax += salesTaxPerProduct;
                basketTotalPrice += finalItemPriceWithTax;
            }

            Assert.Equal(7.65M, basketTotalTax);
            Assert.Equal(65.15M, basketTotalPrice);
        }

        //Input 3

        [Fact]
        public void CalculateSalesTaxForImportedBottleOfPerfumeNo2Item()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBottleOfPerfumeNo2;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(4.2M, salesTaxOnProduct);
            Assert.Equal(32.19M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForBottleOfPerfumeItem()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.BottleOfPerfume;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(1.9M, salesTaxOnProduct);
            Assert.Equal(20.89M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForParacetamolItem()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.BottleOfParacetamol;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(0M, salesTaxOnProduct);
            Assert.Equal(9.75M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForImportedBoxOfChocolates2Item()
        {
            decimal salesTaxOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBoxOfChocolates2Item;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    salesTaxOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var salesTax = new SalesTax
            {
                SalesTaxCalculated = salesTaxOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (salesTaxOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
            }

            Assert.Equal(0.6M, salesTaxOnProduct);
            Assert.Equal(11.85M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateBasketInput3Results()
        {
            var manager = new SalesTaxManager();

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;

            foreach (var basketItem in BasketTestData.BuildInputThreeBasket.Items)
            {
                decimal salesTaxPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        salesTaxPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem.Price);
                    }
                }
                var finalItemPriceWithTax = basketItem.Price;
                var salesTax = new SalesTax
                {
                    SalesTaxCalculated = salesTaxPerProduct,
                    ItemPrice = basketItem.Price
                };

                if (salesTaxPerProduct != 0)
                {
                    finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(salesTax);
                }


                basketTotalTax += salesTaxPerProduct;
                basketTotalPrice += finalItemPriceWithTax;
            }

            Assert.Equal(6.7M, basketTotalTax);
            Assert.Equal(74.68M, basketTotalPrice);
        }

    }
}
