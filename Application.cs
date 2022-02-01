using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW2
{
    static class Application
    {
        public static void Run()
        {
            var productsInShop = Storage.Instance.DownloadGoods();
            while (true)
            {
                Console.WriteLine("             Интернет-магазин \"БОЛЬШАК\"");
                Console.WriteLine("Введите номера товаров, которые хотите добавить в корзину, через пробел");
                Shop.ShowGoods(productsInShop);
                Console.WriteLine($"\nКолличество товаров в вашей корзине: {Basket.Instance.GetProducts().Count}");
                Console.Write("Ваш выбор(Enter для вызова меню): ");
                Shop.ChooseGoods(productsInShop);               
                Console.WriteLine("Нажмите Escape - что бы выйти");
                Console.WriteLine("     Backspace - что бы открыть корзину");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.Backspace:
                        Shop.OpenBasket();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
