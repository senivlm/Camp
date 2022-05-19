using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class DairyProduct : Product
    {
        public readonly int expirationTermInDays;

        public DairyProduct()
        {
            expirationTermInDays = 0;
        }

        public DairyProduct(string name, decimal price, double weight, int expirationDateInDays)
            : base(name, price, weight)
        {
            this.expirationTermInDays = expirationDateInDays;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}| Expiration term: {expirationTermInDays} days");
        }
    }
}
