using System.Collections.Generic;
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
            decimal interestOnProduct = 0;

            var itemTestData = ItemTestData.Book;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }

            var finalItemPriceWithTax = itemTestData.Price;

            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }
            Assert.Equal(0, interestOnProduct);
            Assert.Equal(12.49M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForMusicItem()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.MusicCd;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(1.5M, interestOnProduct);
            Assert.Equal(16.49M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForChocolateBarItem()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.ChocolateBar;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(0M, interestOnProduct);
            Assert.Equal(0.85M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateBasketInput1Results()
        {
            var manager = new SalesTaxManager();

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;

            var basketItems = new List<Item>
            {
                ItemTestData.Book,
                ItemTestData.MusicCd,
                ItemTestData.ChocolateBar
            };

            foreach (var basketItem in basketItems)
            {
                decimal interestPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        interestPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem.Price);
                    }
                }
                var finalItemPriceWithTax = basketItem.Price;

                var interest = new SalesTax
                {
                    SalesTaxCalculated = interestPerProduct,
                    ItemPrice = basketItem.Price
                };
             
                if (interestPerProduct != 0)
                {
                    finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
                }

                basketTotalTax += interestPerProduct;
                basketTotalPrice += finalItemPriceWithTax;
            }
            
            Assert.Equal(1.50M, basketTotalTax);
            Assert.Equal(29.83M, basketTotalPrice);
        }

        //Input 2
        [Fact]
        public void CalculateSalesTaxForImportedBottleOfImportedBoxOfChocolatesItem()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBoxOfChocolates;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }

            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(0.50M, interestOnProduct);
            Assert.Equal(10.50M, finalItemPriceWithTax);
        }
        [Fact]
        public void CalculateSalesTaxForImportedBottleOfPerfumeItem()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBottleOfPerfume;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }

            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(7.15M, interestOnProduct);
            Assert.Equal(54.65M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateBasketInput2Results()
        {
            var manager = new SalesTaxManager();

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;

            var basketItems = new List<Item>
            {
                ItemTestData.ImportedBoxOfChocolates,
                ItemTestData.ImportedBottleOfPerfume
            };

            foreach (var basketItem in basketItems)
            {
                decimal interestPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        interestPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem.Price);
                    }
                }
                var finalItemPriceWithTax = basketItem.Price;
                var interest = new SalesTax
                {
                    SalesTaxCalculated = interestPerProduct,
                    ItemPrice = basketItem.Price
                };

                if (interestPerProduct != 0)
                {
                    finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
                }


                basketTotalTax += interestPerProduct;
                basketTotalPrice += finalItemPriceWithTax;
            }

            Assert.Equal(7.65M, basketTotalTax);
            Assert.Equal(65.15M, basketTotalPrice);
        }

        //Input 3

        [Fact]
        public void CalculateSalesTaxForImportedBottleOfPerfumeNo2Item()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBottleOfPerfumeNo2;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(4.2M, interestOnProduct);
            Assert.Equal(32.19M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForBottleOfPerfumeItem()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.BottleOfPerfume;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(1.9M, interestOnProduct);
            Assert.Equal(20.89M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForParacetamolItem()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.BottleOfParacetamol;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(0M, interestOnProduct);
            Assert.Equal(9.75M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateSalesTaxForImportedBoxOfChocolates2Item()
        {
            decimal interestOnProduct = 0;
            var itemTestData = ItemTestData.ImportedBoxOfChocolates2Item;

            var manager = new SalesTaxManager();

            if (itemTestData.CategoryTax.TaxableItemCategories.Count != 0)
            {
                foreach (var item in itemTestData.CategoryTax.TaxableItemCategories)
                {
                    interestOnProduct += manager.CalculateSalesTaxPerItem(item, itemTestData.Price);
                }
            }
            var finalItemPriceWithTax = itemTestData.Price;
            var interest = new SalesTax
            {
                SalesTaxCalculated = interestOnProduct,
                ItemPrice = itemTestData.Price
            };

            if (interestOnProduct != 0)
            {
                finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
            }

            Assert.Equal(0.6M, interestOnProduct);
            Assert.Equal(11.85M, finalItemPriceWithTax);
        }

        [Fact]
        public void CalculateBasketInput3Results()
        {
            var manager = new SalesTaxManager();

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;

            var basketItems = new List<Item>
            {
                ItemTestData.ImportedBottleOfPerfumeNo2,
                ItemTestData.BottleOfPerfume,
                ItemTestData.BottleOfParacetamol,
                ItemTestData.ImportedBoxOfChocolates2Item
            };

            foreach (var basketItem in basketItems)
            {
                decimal interestPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        interestPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem.Price);
                    }
                }
                var finalItemPriceWithTax = basketItem.Price;
                var interest = new SalesTax
                {
                    SalesTaxCalculated = interestPerProduct,
                    ItemPrice = basketItem.Price
                };

                if (interestPerProduct != 0)
                {
                    finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interest);
                }


                basketTotalTax += interestPerProduct;
                basketTotalPrice += finalItemPriceWithTax;
            }

            Assert.Equal(6.7M, basketTotalTax);
            Assert.Equal(74.68M, basketTotalPrice);
        }

    }
}
