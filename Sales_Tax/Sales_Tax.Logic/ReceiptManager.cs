using System;
using System.Collections.Generic;
using Sales_Tax.Common.Models;

using Sales_Tax.Logic.Models;

namespace Sales_Tax.Logic
{
    public interface IReceiptManager
    {
        Basket CalculateBasketItems(List<ItemDto> items);
    }
    public class ReceiptManager : IReceiptManager
    {
        private readonly ISalesTaxManager salesTaxManager;

        public ReceiptManager(ISalesTaxManager salesTaxManager)
        {
            this.salesTaxManager = salesTaxManager;
        }

        public Basket CalculateBasketItems(List<Item> basketItems)
        {

            decimal basketTotalTax = 0;
            decimal basketTotalPrice = 0;
            var ourBasket = new Basket();

            foreach (var basketItem in basketItems)
            {
                decimal interestPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var itemCategory in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        interestPerProduct +=
                            salesTaxManager.CalculateSalesTaxPerItem(itemCategory, basketItem.Price);
                    }
                }

                var finalItemPriceWithTax = basketItem.Price;

                var interest = new Interest
                {
                    InterestCalculated = interestPerProduct,
                    ItemPrice = basketItem.Price
                };

                if (interestPerProduct != 0)
                {
                    finalItemPriceWithTax = salesTaxManager.CalculateItemFinalPriceWithTax(interest);
                }

                var item = new Item
                {
                    Name = basketItem.Name,
                    Price = basketItem.Price,
                    Quantity = basketItem.Quantity,
                    PriceAfterTax = finalItemPriceWithTax

                };
                ourBasket.Items.Add(item);

            }

            return ourBasket;
        }
        //public Receipt PrintReceipt(ReceiptDetails receiptDetails, Basket basket)
        //{

        //    //string basketName = "Input 1";
        //    //var manager = new SalesTaxManager();

        //    //double basketTotalTax = 0;
        //    //double basketTotalPrice = 0;

        //    //var basketItems = new List<Item>
        //    //{
        //    //    ItemTestData.BookItem,
        //    //    ItemTestData.MusicCdItem,
        //    //    ItemTestData.ChocolateBarItem
        //    //};

        //    //foreach (var basketItem in basketItems)
        //    //{
        //    //    double interestPerProduct = 0;

        //    //    if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
        //    //    {
        //    //        foreach (var item in basketItem.CategoryTax.TaxableItemCategories)
        //    //        {
        //    //            interestPerProduct += manager.CalculateSalesTaxPerItem(item, basketItem);
        //    //        }
        //    //    }
        //    //    var finalItemPriceWithTax = basketItem.Price;
        //    //    if (interestPerProduct != 0)
        //    //    {
        //    //        finalItemPriceWithTax = manager.CalculateItemFinalPriceWithTax(interestPerProduct, basketItem.Price);
        //    //    }

        //    //    basketTotalTax += interestPerProduct;
        //    //    basketTotalPrice += finalItemPriceWithTax;
        //    //}

        //    //basketTotalTax = Math.Round(basketTotalTax, 2);
        //    //basketTotalPrice = Math.Round(basketTotalPrice, 2);

        //    //var basket = new Basket
        //    //{
        //    //    Items = basketItems
        //    //};

        //    //var receiptDetails = new ReceiptDetails
        //    //{
        //    //    BasketName = basketName,
        //    //    SalesTax = basketTotalTax,
        //    //    Total = basketTotalPrice
        //    //};

        //    //var receipt = new Receipt
        //    //{
        //    //    ReceiptDetails = receiptDetails,
        //    //    Basket = basket
        //    //};


        //    return null;
        //}
    }
}
