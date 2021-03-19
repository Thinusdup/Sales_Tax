using System;
using Sales_Tax.Models;

namespace Sales_Tax.Logic
{
    public class SalesTaxManager
    {
        /// <summary>
        /// This method calculates the sales tax only per item
        /// </summary>
        /// <param name="itemCategory"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public decimal CalculateSalesTaxPerItem(TaxableItemCategory itemCategory, Item item)
        {
            var taxRate = RoundUp(itemCategory.CategoryTaxRate * item.Price / 100);

            return taxRate;
        }


        /// <summary>
        /// For a tax rate of n%, a shelf price of p contains (np / 100 rounded up to the nearest 0.05) amount of tax.
        /// The statement above I understand and read it to "UP" to the nearest
        /// My understanding of rounding "Up" to the nearest would indeed work with the below method, I hope I understood the statement right
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal RoundUp(decimal value)
        {
            var ceiling = Math.Ceiling(value * 20) / 20;
      
            return ceiling;
        }

      /// <summary>
      /// This method Calculates Item Final Price
      /// </summary>
      /// <param name="interestCalculated"></param>
      /// <param name="itemPrice"></param>
      /// <returns></returns>
        public decimal CalculateItemFinalPriceWithTax(decimal interestCalculated, decimal itemPrice)
        {
            var finalItemPrice = Math.Round(interestCalculated + itemPrice,2);

            return finalItemPrice;
        }

      public void CalculateBasketTotalSalesTax(decimal interestCalculated, decimal itemPrice)
      {
        
      }

      public void CalculateBasketTotal(decimal interestCalculated, decimal itemPrice)
      {

      }


    }
}
