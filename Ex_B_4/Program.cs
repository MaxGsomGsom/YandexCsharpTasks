using System.IO;

namespace Ex_B_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            string s = lines[0];
            string t = lines[1];

            bool canBeConcatenated = false;

            if (s.Length % t.Length == 0)
            {
                canBeConcatenated = true;
                int pos = 0;
                while (pos < s.Length)
                {
                    if (s.Substring(pos, t.Length) != t)
                    {
                        canBeConcatenated = false;
                        break;
                    }
                    pos += t.Length;
                }
            }

            File.WriteAllText("output.txt", canBeConcatenated ? "Yes" : "No");
        }
    }
}

