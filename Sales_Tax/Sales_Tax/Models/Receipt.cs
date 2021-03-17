using System.Threading.Tasks;

namespace Sales_Tax.Models
{
   public class Receipt 
   {
       public  Task<Receipt> CreateReceipt(Receipt receipt)
       {
            ReceiptDetails receiptDetails = new ReceiptDetails();
            receiptDetails.BasketName = "Input 1";
            

           return  Receipt();
       }

        private  Task<Receipt> Receipt()
        {
           
        }

     
   }
 
}
