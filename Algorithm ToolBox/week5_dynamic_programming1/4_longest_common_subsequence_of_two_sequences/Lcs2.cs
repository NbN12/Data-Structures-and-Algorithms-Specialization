using System;

namespace longest_common_subsequence_of_two_sequences
{
    class Lcs2
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var m = Convert.ToInt32(Console.ReadLine());
            var b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{GetLcs2(a, b)}");
        }

        private static int GetLcs2(int[] a, int[] b)
        {
            var len = new int[a.Length + 1, b.Length + 1];
            for (int i = 0; i <= a.Length; i++)
            {
                for (int j = 0; j <= b.Length; j++)
                {
                    if (i == 0 || j == 0)
                        len[i, j] = 0;
                    else if (a[i - 1] == b[j - 1])
                        len[i, j] = len[i - 1, j - 1] + 1;
                    else
                        len[i, j] = Math.Max(len[i - 1, j], len[i, j - 1]);
                }
            }
            return len[a.Length, b.Length];
        }
    }
}
