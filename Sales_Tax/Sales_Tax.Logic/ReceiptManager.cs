using System.Collections.Generic;
using System.Threading.Tasks;
using Sales_Tax.Common.Models;

using Sales_Tax.Logic.Models;

namespace Sales_Tax.Logic
{
    public interface IReceiptManager
    {
       Task<Receipt> PrintReceiptAsync(Basket basket);
    }
    public class ReceiptManager : IReceiptManager
    {
        private readonly ISalesTaxManager _salesTaxManager;
        public ReceiptManager(ISalesTaxManager salesTaxManager)
        {
            _salesTaxManager = salesTaxManager;
        }

        public async Task<Receipt> PrintReceiptAsync(Basket basket)
        {
            var receipt = new Receipt
            {
                ReceiptDetails = await BuildReceipt(basket)
            };

            return receipt;
        }
        private async Task<ReceiptDetails> BuildReceipt(Basket basket)
        {
            var calculatedBasket = await CalculateBasketItems(basket);

            var receiptDetails = new ReceiptDetails
            {
                Basket = calculatedBasket
            };
            foreach (var item in calculatedBasket.Items)
            {
                receiptDetails.SalesTax += item.SalesTaxAmount;
                receiptDetails.Total += item.PriceAfterTax;
            }

            return receiptDetails;
        }

        private  Task<Basket> CalculateBasketItems(Basket basket)
        {

            var basketItems = basket.Items;
            var listItems = new List<Item>();
            var ourBasket = new Basket
            {
                BasketName = basket.BasketName
            };

            foreach (var basketItem in basketItems)
            {
                decimal salesTaxPerProduct = 0;

                if (basketItem.CategoryTax.TaxableItemCategories.Count != 0)
                {
                    foreach (var itemCategory in basketItem.CategoryTax.TaxableItemCategories)
                    {
                        salesTaxPerProduct +=
                            _salesTaxManager.CalculateSalesTaxPerItem(itemCategory, basketItem.Price);
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
                    finalItemPriceWithTax = _salesTaxManager.CalculateItemFinalPriceWithTax(salesTax);
                }

                var item = new Item
                {
                    Name = basketItem.Name,
                    Price = basketItem.Price,
                    Quantity = basketItem.Quantity,
                    PriceAfterTax = finalItemPriceWithTax,
                    SalesTaxAmount = salesTaxPerProduct

                };
                
                listItems.Add(item);
            }
            ourBasket.Items = listItems;

            return Task.FromResult(ourBasket);
        }

    }
}
