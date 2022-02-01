using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW2
{
    class Storage
    {
        public static readonly List<Product> GoodsInStock = new List<Product>();
        private static Storage instance = null;
        private static readonly object padlock = new object();
        Storage()
        {
        }
        public static Storage Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Storage();
                    }
                    return instance;
                }
            }
        }
        public List<Product> DownloadGoods()
        {
            GoodsInStock.Add(new Product("Хлеб", 18.5m));
            GoodsInStock.Add(new Product("Колбаса", 30.0m));
            GoodsInStock.Add(new Product("Мороженое", 12.5m));
            GoodsInStock.Add(new Product("Пиво 1л.", 20.3m));
            GoodsInStock.Add(new Product("Сигареты", 29.6m));
            GoodsInStock.Add(new Product("Гречка", 38.4m));
            GoodsInStock.Add(new Product("Молоко 1л.", 16.8m));
            GoodsInStock.Add(new Product("Пельмени 1кг.", 23.7m));
            GoodsInStock.Add(new Product("Оливковое масло 1л.", 31.3m));
            GoodsInStock.Add(new Product("Картошка 1кг.", 12.5m));
            return GoodsInStock;
        }
        public static void TransferFromBasketToOrder(Basket basket, Order order)
        {
            foreach (var item in basket.GetProducts())
            {
                var orderList = order.GetProducts();
                if (orderList.ContainsKey(item))
                {
                    order.UpdateProductCount(item);
                }
                else
                {
                    order.AddProduct(item);
                }
            }
        }
    }
}
