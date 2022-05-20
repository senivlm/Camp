using Task2;

Product apple = new Product(name: "Apple", price: 12.50m, weight: 0.725);
Product banana = new Product("Banana", 47m, 0.55);
Product orange = new Product("Milk", 36m, 1);

Buy basket = new Buy(apple, banana);
basket.Add(apple, banana, orange);

Check.DisplayInfo(basket);

Meat mutton = new Meat("Mutton", 10m, 2.25, MeatGradeEnum.FirstGrade, MeatTypeEnum.Mutton);
Meat veal = new Meat()
{
    MeatType = MeatTypeEnum.Veal
};

Console.WriteLine("\nBefore the change: {0}", mutton.Price);
mutton.ChangePrice(10);
Console.WriteLine("After the change: {0}", mutton.Price);

DairyProduct sourcream = new DairyProduct("Sourcream", 10m, 0.50, 33);

Console.WriteLine("\nBefore the change: {0}", sourcream.Price);
sourcream.ChangePrice(10);
Console.WriteLine("After the change: {0}", sourcream.Price);

Console.ReadKey();