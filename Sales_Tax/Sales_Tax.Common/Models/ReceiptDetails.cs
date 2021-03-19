namespace Sales_Tax.Common.Models
{
    public class ReceiptDetails
    {
        public string BasketName { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Total { get; set; }
    }
}
