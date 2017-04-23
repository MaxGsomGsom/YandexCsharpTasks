using System.IO;

namespace Ex_A_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllLines("input.txt")[0];

            int[,] pairs = new int[26, 26];

            int one, two;

            for (int i = 0; i < line.Length - 1; i++)
            {
                //97 - номер символа 'a'
                one = line[i] - 97;
                two = line[i + 1] - 97;
                pairs[one, two]++;
                pairs[two, one]++;
            }

            int result = 0;

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    if (pairs[i, j] > 0) result++;
                }
            }

            File.WriteAllText("output.txt", result.ToString());

        }
    }
}
