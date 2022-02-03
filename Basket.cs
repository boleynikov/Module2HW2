using System.Collections.Generic;

namespace Module2HW2
{
    class Basket
    {
        private readonly List<Product> ProductsInBasket;
        public Basket()
        {
            ProductsInBasket = new List<Product>();
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
