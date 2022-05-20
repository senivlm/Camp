using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Storage
    {
        private List<Product> _products = new();
        public int Capasity => _products.Count;

        public Storage() { }
        public Storage(List<Product> products)
        {
            _products = products;
        }

        public Product this[int index]
                {
                    get => _products[index];
                    set => _products[index] = value;
                }

        public void AddProducts()
        {
            bool isExit;
            do
            {
                Console.WriteLine("\nSelect category of the product: ");
                Console.WriteLine("[0] - Product\n[1] - Meat\n[2] - Dairy product");

                Console.Write("Option: ");
                string choice = Console.ReadLine();
                if (choice != "0" && choice != "1" && choice != "2")
                    throw new ArgumentOutOfRangeException("Option must be 0, 1 or 2.");

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.Write("Weight: ");
                double weight = double.Parse(Console.ReadLine());

                switch (choice)
                {
                    case "0":
                        _products.Add(new Product(name, price, weight));
                        break;
                    case "1":
                        Console.Write("Grade (FirstGrade or SecondGrade): ");
                        string input = Console.ReadLine();
                        MeatGradeEnum mge = (MeatGradeEnum)Enum.Parse(typeof(MeatGradeEnum), input);

                        Console.Write("Type (Mutton, Veal, Pork, Chicken): ");
                        input = Console.ReadLine();
                        MeatTypeEnum mte = (MeatTypeEnum)Enum.Parse(typeof(MeatTypeEnum), input);

                        _products.Add(new Meat(name, price, weight, mge, mte));
                        break;
                    case "2":
                        Console.Write("Expritarion term in days: ");
                        int expTerm = int.Parse(Console.ReadLine());

                        _products.Add(new DairyProduct(name, price, weight, expTerm));
                        break;
                }
                Console.WriteLine("Added!");
                Console.WriteLine();

                Console.WriteLine("Press any key to continue or Q to quit: ");
                string ch = Console.ReadLine();
                isExit = ch.Equals("q", StringComparison.OrdinalIgnoreCase);

            } while (!isExit);
        }
        public void PrintAll()
        {
            Console.WriteLine("Storage contains:");
            foreach (Product prod in _products)
            {
                Console.WriteLine(prod.ToString());
            }
            Console.WriteLine();
        }
        
        public List<Meat> FindAllMeatProducts()
        {
            List<Meat> meatProducts = new List<Meat>();
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i] is Meat meat)
                {
                    meatProducts.Add(meat);
                }
            }
            return meatProducts;

            //var meatProductsLinq = from prod in _products
            //                       where prod is Meat
            //                       select prod as Meat;
            //return meatProductsLinq.ToList();
        }
        public void ChangePrices(double percentage)
        {
            foreach (Product product in _products)
            {
                product.ChangePrice(percentage);
            }
            //_products.ForEach(x => x.ChangePrice(percentage));
        }

        public override string ToString()
        {
            return string.Format($"Storage with {_products.Count} items.");
        }
    }
}
