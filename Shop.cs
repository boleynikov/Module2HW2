using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW2
{
    static class Shop
    {
        public static void OpenBasket(Basket basket)
        {
            Console.Clear();
            Console.WriteLine("Ваша корзина:");
            ShowGoods(basket.GetProducts());
            Console.WriteLine(" {0,4} | {1,19}  | {2,7} |", "", "Сумма заказа", basket.TotalPrice);
            Console.WriteLine("Нажмите Escape - что бы вернуться");
            Console.WriteLine("     Backspace - что бы оформить заказ");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.Backspace:
                    CreateOrder(basket);
                    break;
            }
        }
        public static void CreateOrder(Basket basket)
        {
            if (basket.GetProducts().Count == 0)
            {
                Console.WriteLine("Вы ещё не выбрали товар в корзину\nНажмите Enter");
                Console.ReadLine();
                return;
            }
            Order order = new Order();
            Storage.TransferFromBasketToOrder(basket, order);
            ShowOrder(order, basket);
            basket.ClearBasket();
        }
        public static void ShowOrder(Order order, Basket basket)
        {
            var products = order.GetProducts();
            Console.Clear();
            Console.WriteLine($"На вас оформлен заказ номер: {order.Id}");
            foreach (var item in products)
            {
                Console.WriteLine(" | {0,19}  | {1,7} шт.|", item.Key.Name, item.Value);
            }
            Console.WriteLine(" | {0,19}  | {1,7}    |", "Сумма", basket.TotalPrice);
            Console.WriteLine("Нажмите Enter");
            Console.ReadLine();
        }
        public static void ShowGoods(List<Product> list)
        {
            Console.WriteLine(" {0,4} | {1,19}  | {2,7} |", "№", "Название", "Цена");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(" {0,4}.| {1,19}  | {2,7} |", i, list[i].Name, list[i].Price);
            }
        }
        public static void ChooseGoods(List<Product> products, Basket basket)
        {
            string str = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(str))
                return;
            string[] lst = str.Split(' ');
            int numProduct;
            for (int i = 0; i < lst.Length; i++)
            {
                if (int.TryParse(lst[i], out numProduct) == false)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Вы неправильно ввели номер товара");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (numProduct > products.Count - 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Слишком большой номер товара");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    basket.AddProduct(products[numProduct]);

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Товар добавлен в корзину");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
