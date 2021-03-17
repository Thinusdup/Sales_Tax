namespace Sales_Tax.Models
{
   public class Item
    {
        public  string Name { get; set; }
        public double Price { get; set; }
        public CategoryTax CategoryTax { get; set; }

    }
}
