using System;
using Sales_Tax.Models;

namespace Sales_Tax.Logic
{
    public class SalesTaxManager
    {
        public double CalculateSalesTaxPerItem(ItemCategory itemCategory, Item item)
        {
            var taxRate = itemCategory.CategoryTaxRate * item.Price / 100;

            return taxRate;
        }

  
    }
}
