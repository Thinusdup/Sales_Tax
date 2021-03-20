﻿using System;
using Sales_Tax.Common.Models;

namespace Sales_Tax.Logic
{
    public interface ISalesTaxManager
    {
        decimal CalculateSalesTaxPerItem(TaxableItemCategory itemCategory, decimal itemPrice);
        decimal CalculateItemFinalPriceWithTax(SalesTax interest);
    }
    public class SalesTaxManager: ISalesTaxManager
    {
        /// <summary>
        /// This method calculates the sales tax only per item
        /// </summary>
        /// <param name="itemCategory"></param>
        /// <param name="itemPrice"></param>
        /// <returns></returns>
        public decimal CalculateSalesTaxPerItem(TaxableItemCategory itemCategory, decimal itemPrice)
        {
            var taxRate = RoundUpToNearestZeroPointZeroFive(itemCategory.CategoryTaxRate * itemPrice / 100);

            return taxRate;
        }


        /// <summary>
        /// This method rounds any decimal number up to the the nearest 0.05 amount.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public decimal RoundUpToNearestZeroPointZeroFive(decimal value)
        {
            var ceiling = Math.Ceiling(value * 20) / 20;
      
            return ceiling;
        }

        /// <summary>
        /// This method Calculates the Item Final Price including the tax on that item
        /// </summary>
        /// <param name="interest"></param>
        /// <returns></returns>
        public decimal CalculateItemFinalPriceWithTax(SalesTax interest)
        {
            var finalItemPrice = Math.Round(interest.SalesTaxCalculated + interest.ItemPrice,2);

            return finalItemPrice;
        }

    }
}
