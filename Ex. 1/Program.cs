using System;

namespace Ex._1
{
    class Program
    {
        static void Main(string[] args)
        {
            long input = long.Parse(Console.ReadLine());
            long power = 0;
            long temp = 0;

            if (input != 0)
            {
                temp = 1;
                while (temp <= input)
                {
                    temp *= 2;
                    power++;
                }
            }

            Console.WriteLine(power);
            Console.ReadKey();
        }
    }
}
