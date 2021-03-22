using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sales_Tax.Common.Models;
using Sales_Tax.Data;
using Sales_Tax.Logic;

namespace Sales_Tax
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Setup our Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISalesTaxManager, SalesTaxManager>()
                .AddSingleton<IReceiptManager, ReceiptManager>()
                .BuildServiceProvider();

            var receiptManager = serviceProvider.GetService<IReceiptManager>();

            //Print Receipt Details per Basket
            Task.Run(async () =>
            {
                foreach (var basket in BasketsToExecute())
                {
                    var receipt = await receiptManager.PrintReceiptAsync(basket);

                    Console.WriteLine(receipt.ReceiptDetails.Basket.BasketName);
                    foreach (var item in receipt.ReceiptDetails.Basket.Items)
                    {
                        Console.WriteLine(item.Quantity.ToString() + ' ' + item.Name + " : " + item.PriceAfterTax.ToString("0.00"));
                    }
                    Console.WriteLine("Sales Taxes: " + receipt.ReceiptDetails.SalesTax.ToString("0.00"));
                    Console.WriteLine("Total: " + receipt.ReceiptDetails.Total.ToString("0.00"));
                    Console.WriteLine();
                    Console.WriteLine("================================================================================================");
                    Console.WriteLine();

                }
            }).GetAwaiter().GetResult();

            Console.ReadLine();
        }

        //Build Basket list to execute from test data
        private static IEnumerable<Basket> BasketsToExecute()
        {
            var baskets = new List<Basket>
            {
                BasketTestData.BuildInputOneBasket,
                BasketTestData.BuildInputTwoBasket,
                BasketTestData.BuildInputThreeBasket
            };

            return baskets;
        }

    }
}
