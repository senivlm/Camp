using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class Vector
    {
        private int[] _array;
        public int Lenght => _array.Length;

        #region Ctors

        public Vector(int[] arr)
        {
            _array = arr;
        }
        public Vector(int n)
        {
            _array = new int[n];
        }
        public Vector()
        {
            _array = Array.Empty<int>();
        }

        #endregion

        public int this[int index]
        {
            get => _array[index];
            set => _array[index] = value;
        }

        public override string ToString()
        {
            return string.Join(' ', _array);
        }

        #region Methods

        public void RandomInitialization(int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < _array?.Length; i++)
            {
                _array[i] = random.Next(min, max);
            }
        }

        public void InitShuffle()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = i + 1;
            }
            Random random = new Random();
            _array = _array.OrderBy(x => random.Next()).ToArray();
        }
        public Pair[] CalculateFrequency()
        {
            var res = _array
                .GroupBy(x => x)
                .Select(x => new Pair(x.Key, x.Count()))
                .ToArray();

            return res;
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
            int lenght = _array.Length / 2;

            for (int i = 0; i < lenght; i++)
            {
                (_array[i], _array[lenght - 1 - i]) = (_array[lenght - 1 - i], _array[i]);
            }
        }
        public string FindLongestSequence()
        {
            int? resNum = null;
            int maxCount = 1;
            int count = 1;

            for (int i = 0; i < _array.Length - 1; i++)
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
                return $"Number {resNum} occurs {maxCount} times in a row.";
            else
                return "Every number occurs only once.";
        }

        #endregion

        #region Sort

        public static void QuickSort(Vector vec, int start, int end)
        {
            if (start < end)
            {
                int pivotIdx = Partition(vec, start, end);

                QuickSort(vec, start, pivotIdx - 1);
                QuickSort(vec, pivotIdx + 1, end);
            }
        }
        private static int Partition(Vector vec, int start, int end)
        {
            int pivot = vec[end];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if (vec[j] < pivot)
                {
                    (vec[++i], vec[j]) = (vec[j], vec[i]);
                }
            }
            (vec[i + 1], vec[end]) = (vec[end], vec[i + 1]);

            return i + 1;
        }

        public static void MergeSort(Vector vec, int l, int r)
        {
            if (l < r)
            {
                int middlePoint = l + (r - l) / 2;

                MergeSort(vec, l, middlePoint);
                MergeSort(vec, middlePoint + 1, r);

                Merge(vec, l, middlePoint, r);
            }
        }
        private static void Merge(Vector vec, int l, int middlePoint, int r)
        {
            int sizeL = middlePoint - l + 1,
                sizeR = r - middlePoint;

            int[] tempL = new int[sizeL],
                tempR = new int[sizeR];


            int i, j;
            for (i = 0; i < sizeL; ++i)
                tempL[i] = vec[l + i];

            for (j = 0; j < sizeR; ++j)
                tempR[j] = vec[middlePoint + 1 + j];

            i = 0;
            j = 0;
            int idx = l;


            while (i < sizeL && j < sizeR)
            {
                if (tempL[i] <= tempR[j])
                {
                    vec[idx] = tempL[i];
                    i++;
                }
                else
                {
                    vec[idx] = tempR[j];
                    j++;
                }
                idx++;
            }

            while (i < sizeL)
            {
                vec[idx] = tempL[i];
                i++;
                idx++;
            }

            while (j < sizeR)
            {
                vec[idx] = tempR[j];
                j++;
                idx++;
            }
        }
        public static void MergeSortWithFiles(string filename)
        {
            var fh = new FileHandler(filename);

            (string file1, string file2) = fh.Split();
            Sort(file1);
            Sort(file2);
            fh.Dispose();

            fh.Merge(file1, file2);

            void Sort(string path)
            {
                FileHandler hf = new FileHandler(path);
                Vector v = hf.ReadVector();
                MergeSort(v, 0, v.Lenght - 1);
                hf.WriteVector(v);
            }
        }

        public static void HeapSort(Vector v)
        {
            int n = v.Lenght;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(v, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                // Move root to end.
                (v[0], v[i]) = (v[i], v[0]);

                Heapify(v, i, 0);
            }
        }
        private static void Heapify(Vector v, int n, int root)
        {
            int largest = root;
            int leftNode = 2 * root + 1;
            int rightNode = 2 * root + 2;

            if (leftNode < n && v[leftNode] > v[largest])
                largest = leftNode;

            if (rightNode < n && v[rightNode] > v[largest])
                largest = rightNode;

            if (largest != root)
            {
                (v[largest], v[root]) = (v[root], v[largest]);

                // Recursively update subtree.
                Heapify(v, n, largest);
            }
        }

        #endregion
    }
}
