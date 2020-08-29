using System;

namespace longest_common_subsequence_of_three_sequences
{
    class Lcs3
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var m = Convert.ToInt32(Console.ReadLine());
            var b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var o = Convert.ToInt32(Console.ReadLine());
            var c = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{GetLcs3(a, b, c)}");
        }

        private static int GetLcs3(int[] a, int[] b, int[] c)
        {
            var len = new int[a.Length + 1, b.Length + 1, c.Length + 1];
            for (int i = 0; i <= a.Length; i++)
            {
                for (int j = 0; j <= b.Length; j++)
                {
                    for (int k = 0; k <= c.Length; k++)
                    {
                        if (i == 0 || j == 0 || k == 0)
                            len[i, j, k] = 0;
                        else if (a[i - 1] == b[j - 1] && b[j - 1] == c[k - 1])
                            len[i, j, k] = len[i - 1, j - 1, k - 1] + 1;
                        else
                            len[i, j, k] = Math.Max(len[i - 1, j, k], Math.Max(len[i, j - 1, k], len[i, j, k - 1]));
                    }
                }
            }
            return len[a.Length, b.Length, c.Length];
        }
    }
}
