using Sales_Tax.Common.Models;

namespace Sales_Tax.Logic.Models
{
   public class ReceiptDetails
    {
        public Basket Basket { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}
