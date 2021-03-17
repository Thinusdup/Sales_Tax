using System.Collections.Generic;

namespace Sales_Tax.Models
{
   public class Receipt 
   {
       public ReceiptDetails ReceiptDetails { get; set; }
       public List<Item> Items { get; set; }

   }
 
}
