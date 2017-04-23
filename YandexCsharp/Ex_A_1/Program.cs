using System.IO;
using System;

namespace Ex_A_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            string[] line = lines[0].Split(' ');
            int x1 = int.Parse(line[0]), y1 = int.Parse(line[1]),
                x2 = int.Parse(line[2]), y2 = int.Parse(line[3]);

            line = lines[1].Split(' ');
            int a1 = int.Parse(line[0]), b1 = int.Parse(line[1]),
                a2 = int.Parse(line[2]), b2 = int.Parse(line[3]);


            int dx = 0;
            int dy = 0;

            //рассматриваем прям-ки по ОХ

            //если не пересекаются
            if (x2 <= a1 || a2 <= x1)
                dx = 0;
            //если второй лежит левее
            else if (a1 <= x1)
            {
                //если второй лежит внутри первого
                if (a2 >= x2)
                    dx = x2 - x1;
                //если второй просто пересекает первый
                else
                    dx = a2 - x1;
            }
            //если второй лежит правее
            else if (a1 > x1)
            {
                //если первый лежит внутри второго
                if (a2 <= x2)
                    dx = a2 - a1;
                //если первый просто пересекает второй
                else
                    dx = x2 - a1;
            }


            //если не пересекаются
            if (y2 <= b1 || b2 <= y1)
                dy = 0;
            //если второй лежит выше
            else if (b1 <= y1)
            {
                //если второй лежит внутри первого
                if (b2 >= y2)
                    dy = y2 - y1;
                //если второй просто пересекает первый
                else
                    dy = b2 - y1;
            }
            //если второй лежит ниже
            else if (b1 > y1)
            {
                //если первый лежит внутри второго
                if (b2 <= y2)
                    dy = b2 - b1;
                //если первый просто пересекает второй
                else
                    dy = y2 - b1;
            }

            int result = Math.Abs(dx * dy);

            File.WriteAllText("output.txt", result.ToString());

        }
    }
}
