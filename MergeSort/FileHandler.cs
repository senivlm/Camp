using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    internal class FileHandler : IDisposable
    {
        private readonly string _path;
        private StreamReader _sr;

        public int Count { get; set; } = 0;

        public FileHandler() : this(null) { }
        public FileHandler(string path)
        {
            _path = path;
            _sr = new StreamReader(path);

            if (path != null)
            {
                // Read first line with count of numbers.
                Count = Convert.ToInt32(_sr.ReadLine());
            }
        }

        public override string ToString()
        {
            return $"This file handler operates on:\n{_path}";
        }

        public Vector? ReadVector()
        {
            try
            {
                int[] arr;
                using (StreamReader sr = new StreamReader(_path))
                {
                    // Skip line with count of numbers.
                    sr.ReadLine();

                    // Read vector.
                    arr = sr.ReadToEnd().Split(' ')
                        .Select(x => Convert.ToInt32(x))
                        .ToArray();
                }
                return new Vector(arr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to read from file:");
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public void WriteVector(Vector v)
        {
            // Close StreamReader with the same path.
            _sr.Dispose();
            try
            {
                using (StreamWriter sw = new StreamWriter(_path))
                {
                    // Write count of numbers.
                    sw.WriteLine(v.Lenght);

                    // Write vector.
                    sw.Write(string.Join(' ', v));

                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to write to file:");
                Console.WriteLine(ex.Message);
            }
            // Open StreamReader with the same path. 
            _sr = new StreamReader(_path);
            _sr.ReadLine();
        }
        public void SplitIntoTwoFiles()
        {
            using (StreamReader sr = new StreamReader(_path))
            {
                // Read line with count of numbers.
                int countInFile = Convert.ToInt32(sr.ReadLine());

                int count = countInFile / 2;

                Vector v1 = ReadToVector(sr, count);
                FileHandler fh1 = new FileHandler(@"C:\Users\gagar\source\repos\Camp\MergeSort\assets\arr1.txt");
                fh1.WriteVector(v1);

                Vector v2 = ReadToVector(sr, countInFile - count);
                FileHandler fh2 = new FileHandler(@"C:\Users\gagar\source\repos\Camp\MergeSort\assets\arr2.txt");
                fh2.WriteVector(v2);
            }

            Vector ReadToVector(StreamReader sr, int count)
            {
                var v = new Vector(count);
                var buffer = new StringBuilder();

                for (int i = 0; i < count; i++)
                {
                    char c = (char)sr.Read();
                    while (char.IsDigit(c))
                    {
                        buffer.Append(c);
                        c = (char)sr.Read();
                    }
                    v[i] = Convert.ToInt32(buffer.ToString());
                    buffer.Clear();
                }
                return v;
            }
        }
        public int? ReadNext()
        {
            if (_sr is null)
                return null;

            var buffer = new StringBuilder();

            if (!_sr.EndOfStream)
            {
                char c;
                while (char.IsDigit(c = (char)_sr.Read()))
                {
                    buffer.Append(c);
                }
                return Convert.ToInt32(buffer.ToString());
            }
            else
            {
                _sr.Dispose();
                _sr = null;
                return null;
            }
        }
        public IEnumerable<int> Numbers()
        {
            var buffer = new StringBuilder();

            using (StreamReader sr = new StreamReader(_path))
            {
                // Skip line with count of numbers.
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    char c = (char)sr.Read();
                    if (!char.IsDigit(c))
                    {
                        int num = Convert.ToInt32(buffer.ToString());
                        buffer.Clear();
                        yield return num;
                    }
                    else
                    {
                        buffer.Append(c);
                    }
                }
            }
        }

        public void Dispose()
        {
            _sr.Dispose();
        }
    }
}
