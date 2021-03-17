using System.Collections.Generic;

namespace Sales_Tax.Models
{
   public class Basket
    {
        public int Quantity { get; set; }
        public List<Item> Items { get; set; }
    }
}
