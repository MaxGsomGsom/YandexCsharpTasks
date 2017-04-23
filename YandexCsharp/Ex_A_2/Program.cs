using System.Collections.Generic;
using System.IO;

namespace Ex_A_2
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



            var outFile = File.Create("output.txt");
            var writer = new StreamWriter(outFile);

            List<int> mins = new List<int>();
            string result = "";

            //храним минимальные сигналы в массиве, который сортируем после каждой итеррации
            for (int k = 0; k < array.Count; k++)
            {

                if (mins.Count < 5)
                    mins.Add(array[k]);

                else if (array[k] < mins[4])
                    mins[4] = array[k];

                mins.Sort();

                //вывод очередной строки
                for (int i = mins.Count - 1; i >= 0; i--)
                {
                    writer.Write(mins[i]);
                    if (i == 0)
                    {
                        if (k < (array.Count - 1))
                            writer.Write('\n');
                    }
                    else
                        writer.Write(' ');
                }

            }

            writer.Close();
            outFile.Close();
        }
    }
}