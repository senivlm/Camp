using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Product
    {
        public string Name { get; }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Price must be a positive value.");
                _price = value;
            }
        }

        private double _weight;
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Weight must be a positive number");
                _weight = value;
            }
        }

        public Product() : this("Undefined", 0, 0) { }
        public Product(string name, decimal price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        public override string ToString()
        {
            return string.Format($"Name: {Name,-10}| Cost: {Price,-10}| Weight: {Weight,-10}");
        }

        /// <summary>
        /// Products are equal when they have the same name.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is Product other)
            {
                return Name == other.Name;
            }
            return false;
        }

        public override int GetHashCode() => Name.GetHashCode();

        public static bool operator ==(Product p1, Product p2)
            => p1.Equals(p2);

        public static bool operator !=(Product p1, Product p2)
            => !p1.Equals(p2);
    }
}
