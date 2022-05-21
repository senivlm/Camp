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

        public DairyProduct(string name, decimal price, double weight, int expirationTermInDays)
            : base(name, price, weight)
        {
            this.expirationTermInDays = expirationTermInDays > 0 ? expirationTermInDays : 0;
        }

        public override void ChangePrice(double percentage)
        {
            switch (expirationTermInDays)
            {
                case < 20:
                    percentage += 15;
                    break;
                case < 30:
                    percentage += 10;
                    break;
                case < 60:
                    percentage += 5;
                    break;
                default:
                    break;
            }
            base.ChangePrice(percentage);
        }
        public override string ToString()
        {
            return string.Format($"{base.ToString()}| Expiration term: {expirationTermInDays} days");
        }
    }
}
