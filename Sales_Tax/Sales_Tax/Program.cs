using System;
using Microsoft.Extensions.DependencyInjection;
using Sales_Tax.Logic;

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

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
