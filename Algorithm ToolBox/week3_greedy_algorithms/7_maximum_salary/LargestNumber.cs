using System.Linq;
using System;

namespace maximum_salary
{
    class LargestNumber
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Console.ReadLine().Split(' ');
            Console.Write($"{GetLargestNumber(a)}");
        }

        private static string GetLargestNumber(string[] a)
        {
            var result = String.Empty;
            var temp = String.Empty;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (IsGreaterOrEqual(a[i], a[j]))
                    {
                        temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            foreach (var s in a)
            {
                result += s;
            }
            return result;
        }

        private static bool IsGreaterOrEqual(string v1, string v2)
        {
            return Convert.ToUInt64(v2 + v1) > Convert.ToUInt64(v1 + v2);
        }
    }
}
