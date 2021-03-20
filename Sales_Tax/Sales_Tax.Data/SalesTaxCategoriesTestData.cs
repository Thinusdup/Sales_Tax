using Sales_Tax.Common.Enums;
using Sales_Tax.Common.Models;

namespace Sales_Tax.Data
{
    public class SalesTaxCategoriesTestData
    {
        public static TaxableItemCategory All =>
            new TaxableItemCategory
            {
                Category = (byte)SalesTaxCategoriesEnum.All,
                CategoryTaxRate = 10
            };
        public static TaxableItemCategory ImportTax =>
            new TaxableItemCategory
            {
                Category = (byte)SalesTaxCategoriesEnum.ImportTax,
                CategoryTaxRate = 5
            };

    }
}
