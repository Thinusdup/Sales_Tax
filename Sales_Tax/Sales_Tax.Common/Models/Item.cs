namespace Sales_Tax.Common.Models
{
   public class Item
    {
        public int Quantity { get; set; }
        public  string Name { get; set; }
        public decimal Price { get; set; }
        public CategoryTax CategoryTax { get; set; }
        public decimal SalesTaxAmount { get; set; }
        public decimal PriceAfterTax { get; set; }

    }
}
