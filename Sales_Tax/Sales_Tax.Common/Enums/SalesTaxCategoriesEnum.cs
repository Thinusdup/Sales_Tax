using System.ComponentModel;

namespace Sales_Tax.Common.Enums
{
  public enum SalesTaxCategoriesEnum: byte
    {
        [Description("All")]
        All = 1,
        [Description("ImportTax")]
        ImportTax = 2,
    }
}
