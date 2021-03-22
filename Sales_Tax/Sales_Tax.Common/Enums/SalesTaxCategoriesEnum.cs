using System.ComponentModel;

namespace Sales_Tax.Common.Enums
{
    //Enumerable list of Tax Categories
    public enum SalesTaxCategoriesEnum: byte
    {
        [Description("All")]
        All = 1,
        [Description("ImportTax")]
        ImportTax = 2,
    }
}
