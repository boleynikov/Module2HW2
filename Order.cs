using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2HW2
{
    class Order
    {
        public string Id { get;}
        private static readonly Dictionary<Product, int> orderProducts = new Dictionary<Product, int>();
        public Order()
        {
            Id = new Random().Next(1, 100).ToString();
        }
        public void AddProduct(Product item)
        {
            orderProducts.Add(item, 1);
        }
        public void UpdateProductCount(Product item)
        {
            orderProducts[item]++;
        }
        public Dictionary<Product, int> GetProducts()
        {
            return orderProducts;
        }
    }
}
