using System.Collections.Generic;
using Sales_Tax.Common.Models;

namespace Sales_Tax.Data
{
    public class BasketTestData
    {
        public static Basket BuildInputOneBasket =>
            new Basket
            {
                Items = new List<Item>
                {
                    ItemTestData.Book,
                    ItemTestData.MusicCd,
                    ItemTestData.ChocolateBar
                },
                BasketName = "Input 1:"
            };
        public static Basket BuildInputTwoBasket =>
            new Basket
            {
                Items = new List<Item>
                {
                    ItemTestData.ImportedBoxOfChocolates,
                    ItemTestData.ImportedBottleOfPerfume
                },
                BasketName = "Input 2:"
            };
        public static Basket BuildInputThreeBasket =>
            new Basket
            {
                Items = new List<Item>
                {
                    ItemTestData.ImportedBottleOfPerfumeNo2,
                    ItemTestData.BottleOfPerfume,
                    ItemTestData.BottleOfParacetamol,
                    ItemTestData.ImportedBoxOfChocolates2Item
                },
                BasketName = "Input 3:"
            };

    }
}
