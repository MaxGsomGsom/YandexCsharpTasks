using System.Collections.Generic;
using System.IO;

namespace Ex_A_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            int n = int.Parse(lines[0]);

            //считываем массив чисел
            List<int> array = new List<int>();
            string[] line = lines[1].Split(' ');

            for (int i = 0; i < n; i++)
            {
                array.Add(int.Parse(line[i]));
            }

            //тупо сортируем его и берем первое значение - это минимальное среднее из всех отрезков :)
            array.Sort();

            File.WriteAllText("output.txt", array[0].ToString());
        }
    }
}
