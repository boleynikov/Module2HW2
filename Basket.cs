using System.Collections.Generic;

namespace Module2HW2
{
    class Basket
    {
        private static Basket instance = null;
        private static readonly object padlock = new object();
        private static readonly List<Product> ProductsInBasket = new List<Product>();
        Basket()
        {
        }
        public decimal TotalPrice
        {
            get
            {
                decimal sum = 0;
                foreach (var item in ProductsInBasket)
                {
                    sum += item.Price;
                }
                return sum;
            }
        }
        public static Basket Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Basket();
                    }
                    return instance;
                }
            }
        }
        public List<Product> GetProducts()
        {
            return ProductsInBasket;
        }
        public void AddProduct(Product item)
        {
            ProductsInBasket.Add(item);
        }
        public void ClearBasket()
        {
            ProductsInBasket.Clear();
        }
    }
}
