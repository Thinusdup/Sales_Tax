using System.Threading.Tasks;
using Sales_Tax.Common.Models;
using Sales_Tax.Logic.Models;

namespace Sales_Tax.Logic
{

    /// <summary>
    /// I Prefer to split my interfaces so that developers understand the implementation can have implications
    /// You only want to expose what you really need to when needed 
    /// </summary>
    public interface IReceiptManager
    {
        Task<Receipt> PrintReceiptAsync(Basket basket);
    }
}
