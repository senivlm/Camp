using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Vector
    {
        private readonly int[]? _array;
        public int Lenght => _array?.Length ?? 0;

        public Vector(int[] arr)
        {
            _array = arr;
        }
        public Vector(int n)
        {
            _array = new int[n];
        }
        public Vector() { }

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        /// <summary>
        /// Fills a vector with values that greater than or equals to min and
        /// less than or equal to max.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void RandomInitialization(int min, int max)
        {
            Random random = new Random();
            max++;
            for (int i = 0; i < _array?.Length; i++)
            {
                _array[i] = random.Next(min, max);
            }
        }

        public void RandomInitialization()
        {
            //int index = Array.IndexOf(arr, 2);
            //Console.WriteLine(index);

            Random random = new Random();
            int x;
            for (int i = 0; i < _array.Length; i++)
            {
                while (_array[i] == 0)
                {
                    x = random.Next(1, _array.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == _array[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        _array[i] = x;
                        break;
                    }
                }
            }
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }
            int countDifference = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (_array[i] == pairs[j].Number)
                    {
                        pairs[j].Frequancy++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Frequancy++;
                    pairs[countDifference].Number = _array[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public bool IsPalindrome()
        {
            bool isPalindrom = true;
            for (int i = 0; i < _array?.Length / 2; i++)
            {
                if (_array[i] != _array[_array.Length - 1 - i])
                {
                    isPalindrom = false;
                    break;
                }
            }
            return isPalindrom;
        }
        public void Reverse()
        {
            for (int i = 0; i < _array?.Length / 2; i++)
            {
                (_array[i], _array[_array.Length - 1 - i]) =
                    (_array[_array.Length - 1 - i], _array[i]);
            }

            //Standart method
            //Array.Reverse(_array);
        }
        public void FindLongestSequence()
        {
            int? resNum = null;
            int maxCount = 1;
            int count = 1;

            for (int i = 0; i < _array?.Length - 1; i++)
            {
                if (_array[i] == _array[i + 1])
                {
                    count++;
                }
                else
                {
                    if (count > maxCount)
                    {
                        resNum = _array[i];
                        maxCount = count;
                    }
                    count = 1;
                }
            }

            if (resNum != null)
                Console.WriteLine($"Number {resNum} occurs {maxCount} times.");
            else
                Console.WriteLine("No sequence is found.");
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < _array?.Length; i++)
            {
                str += _array[i] + " ";
            }
            return str;
        }
    }
}
