using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sales_Tax.Common.Models;
using Sales_Tax.Data;
using Sales_Tax.Logic;
using Sales_Tax.Logic.Models;

namespace Sales_Tax
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ISalesTaxManager, SalesTaxManager>()
                .AddSingleton<IReceiptManager, ReceiptManager>()
                .BuildServiceProvider();
            var receiptManager = serviceProvider.GetService<IReceiptManager>();

            //Print Receipt Details per Basket
            Task.Run(async () =>{
                foreach (var basket in BasketsToExecute())
                {
                    var receipt = await receiptManager.PrintReceiptAsync(basket);

                    Console.WriteLine(receipt.ReceiptDetails.Basket.BasketName);
                    foreach (var item in receipt.ReceiptDetails.Basket.Items)
                    {
                        Console.WriteLine(item.Quantity.ToString() + ' ' + item.Name + " : " + item.PriceAfterTax);
                    }
                    Console.WriteLine("Sales Taxes: " + receipt.ReceiptDetails.SalesTax);
                    Console.WriteLine("Total: " + receipt.ReceiptDetails.Total);
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine();

                }}).GetAwaiter().GetResult();

            Console.ReadLine();
        }

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
