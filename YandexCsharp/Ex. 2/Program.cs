using System;
using System.Collections.Generic;
using System.IO;

namespace Ex._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");

            string[] nm = lines[0].Split(' ');

            int n = int.Parse(nm[0]);
            int m = int.Parse(nm[1]);

            int[,] matrix = new int[n, m];

            List<int>[] minsInRows = new List<int>[n];
            List<int>[] minsInCols = new List<int>[m];


            int result = 0; //количество элементов удовлетворяющих условию

            for (int i = 0; i < n; i++)
            {
                string[] line = lines[i + 1].Split(' ');
                for (int k = 0; k < m; k++)
                {
                    matrix[i, k] = int.Parse(line[k]);
                }
            }

            for (int row = 0; row < n; row++)
            {
                minsInRows[row] = new List<int>();

                //поиск индекса минимального элемента в строке
                minsInRows[row].Add(0);
                for (int col = 1; col < m; col++)
                {
                    //если текущий элемент в строке равен значениям в списке, то добавляем его в список
                    if (matrix[row, col] == matrix[row, minsInRows[row][0]])
                    {
                        minsInRows[row].Add(col);
                    }
                    //если текущий элемент в строке меньше элементов в списке, то очищаем список и добавляем текущее в него
                    else if (matrix[row, col] < matrix[row, minsInRows[row][0]])
                    {
                        minsInRows[row].Clear();
                        minsInRows[row].Add(col);
                    }
                }


                foreach (int col1 in minsInRows[row])
                {
                    //если минимальные элементы в столбце не найдены, то находим их
                    if (minsInCols[col1] == null)
                    {
                        minsInCols[col1] = new List<int>();
                        //поиск индекса минимального элемента в столбце
                        minsInCols[col1].Add(0);
                        for (int row1 = 1; row1 < n; row1++)
                        {
                            //если текущий элемент в столбце равен значениям в списке, то добавляем его в список
                            if (matrix[row1, col1] == matrix[minsInCols[col1][0], col1])
                            {
                                minsInCols[col1].Add(row1);
                            }
                            //если текущее элемент в столбце меньше элементов в списке, то очищаем список и добавляем текущий элемент в него
                            else if (matrix[row1, col1] < matrix[minsInCols[col1][0], col1])
                            {
                                minsInCols[col1].Clear();
                                minsInCols[col1].Add(row1);
                            }
                        }

                    }
                }


                //берем индексы минимальных элементов в строке
                foreach (int col2 in minsInRows[row])
                {
                    //если в столбце все элементы минимальные, то просто добавляем текущий элемент к результату
                    if (minsInCols[col2].Count == n) result++;
                    else
                        //берем для этих столбцов индексы минимальных элементов
                        foreach (int row2 in minsInCols[col2])
                        {
                            //если текущая строка и индекс минимального элемента столбца совпадают
                            if (row2 == row) result++;
                        }
                }

            }

            File.WriteAllText("output.txt", result.ToString());
        }
    }
}
