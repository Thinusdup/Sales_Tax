using System;
using Moq;
using Sales_Tax.Data;
using Sales_Tax.Logic;
using Xunit;

namespace Sales_Tax_Tests
{
    public class ReceiptManagerTests
    {
       
        [Fact]
        public async void ThrowArgumentExceptionInputOneBasketNameNullOrEmpty()
        {
            var salesManagerMock = new Mock<ISalesTaxManager>(MockBehavior.Strict);

            var basketData = BasketTestData.BuildInputOneBasket;
            basketData.BasketName = "";
            var receiptManager = new ReceiptManager(salesManagerMock.Object);
           
            await Assert.ThrowsAsync<ArgumentException>(() => receiptManager.PrintReceiptAsync(basketData));
        }
    }
}
