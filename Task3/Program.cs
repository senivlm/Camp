using Task3;

Vector vec = new Vector(10);

vec.RandomInitialization(1, vec.Lenght);

Console.WriteLine(vec.ToString());

vec.Reverse();

Console.WriteLine(vec.ToString());

Vector palindrome = new Vector(new int[] { 1, 2, 3, 2, 1 });
Console.WriteLine($"\n{palindrome}");

Console.WriteLine("Is palindrome? {0}", palindrome.IsPalindrome());

Console.WriteLine("Find longest sequence:");
Vector testVector = new Vector(new int[] { 1, 2, 3, 4, 5, 4, 4, 4, 5, 4, 3, 3, 2 });
Console.WriteLine(testVector.ToString());

testVector.FindLongestSequence();

Console.ReadKey();