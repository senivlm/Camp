using Task1;

Product apple = new Product(name: "Apple", price: 12.50m, weight: 0.725);
Product banana = new Product("Banana", 47m, 0.55);
Product milk = new Product("Milk", 36m, 1);

Buy basket = new Buy(apple, banana);
basket.Add(apple, banana, milk);

Check.DisplayInfo(basket);

Console.ReadKey();