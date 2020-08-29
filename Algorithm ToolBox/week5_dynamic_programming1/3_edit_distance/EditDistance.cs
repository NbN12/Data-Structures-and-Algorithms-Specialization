using System;

namespace _3_edit_distance
{
    class EditDistance
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();
            Console.WriteLine($"{GetEditDistance(str1, str2)}");
        }

        private static int GetEditDistance(string str1, string str2)
        {
            var len1 = str1.Length;
            var len2 = str2.Length;
            var d = new int[len1 + 1, len2 + 1];
            for (int i = 0; i <= len2; i++)
                d[0, i] = i;
            for (int i = 0; i <= len1; i++)
                d[i, 0] = i;
            for (int i = 1; i <= len1; ++i)
            {
                for (int j = 1; j <= len2; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        d[i, j] = d[i - 1, j - 1];
                    else
                        d[i, j] = 1 + Math.Min(d[i, j - 1], Math.Min(d[i - 1, j], d[i - 1, j - 1]));
                }
            }
            return d[len1, len2];
        }
    }
}
