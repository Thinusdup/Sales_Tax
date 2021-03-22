using System;
using System.Collections.Generic;

namespace Sales_Tax.Common.Models
{
   public class Basket
    {
        public string BasketName { get; set; }
        public List<Item> Items { get; set; }
      
    }
}
