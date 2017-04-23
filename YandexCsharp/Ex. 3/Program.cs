using System.Collections.Generic;
using System.IO;

namespace Ex._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            int n = int.Parse(lines[0]);

            List<int> array = new List<int>();
            string[] line = lines[1].Split(' ');

            for (int i = 0; i < n; i++)
            {
                array.Add(int.Parse(line[i]));
            }

            array.Sort();

            int result = 0;
            bool unique = true;

            if (n > 1)
            {
                if (array[n - 1] != array[n - 2]) result = 1;

                for (int pos = 0; pos < (n - 1); pos++)
                {
                    unique = true;
                    while (pos < (n - 1) && array[pos] == array[pos + 1])
                    {
                        pos++;
                        unique = false;
                    }
                    if (unique) result++;
                }
            }
            else result = 1;

            File.WriteAllText("output.txt", result.ToString());
        }
    }
}
