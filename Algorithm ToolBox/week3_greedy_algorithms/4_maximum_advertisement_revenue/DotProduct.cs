using System;

namespace maximum_advertisement_revenue
{
    class dot_product
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{MaxDotProduct(a, b)}");
        }

        private static long MaxDotProduct(int[] a, int[] b)
        {
            Array.Sort(a, (x, y) => y.CompareTo(x));
            Array.Sort(b, (x, y) => y.CompareTo(x));
            long result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result += (long)a[i] * (long)b[i];
            }
            return result;
        }
    }
}
