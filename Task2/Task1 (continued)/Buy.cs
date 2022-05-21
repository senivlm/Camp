using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Buy
    {
        private List<(Product Product, int Count)> _basket = new();

        public Buy() { }
        public Buy(params Product[] products) => Add(products);

        public decimal TotalCost() => _basket.Sum(x => x.Count * x.Product.Price);
        public double TotalWeight() => _basket.Sum(x => x.Count * x.Product.Weight);
        public List<(Product Product, int Count)> GetListOfProducts() => _basket;
        public void Add(params Product[] products)
        {
            foreach (Product product in products)
            {
                bool isInBasket = false;
                for (int i = 0; i < _basket.Count; i++)
                    if (_basket[i].Product == product)
                    {
                        _basket[i] = (product, _basket[i].Count + 1);
                        isInBasket = true;
                        break;
                    }

                if (!isInBasket)
                    _basket.Add((product, 1));
            }
        }
    }
}
