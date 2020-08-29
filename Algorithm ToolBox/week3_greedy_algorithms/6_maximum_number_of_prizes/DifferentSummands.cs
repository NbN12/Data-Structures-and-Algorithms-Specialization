using System;
using System.Collections.Generic;

namespace maximum_number_of_prizes
{
    class DifferentSummands
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var summands = OptimalSummands(n);
            Console.WriteLine($"{summands.Count}");
            foreach (var s in summands)
            {
                Console.Write($"{s} ");
            }
        }

        private static List<int> OptimalSummands(int n)
        {
            List<int> result = new List<int>();
            for (int i = n, l = 1; i > 0; l++)
            {
                if (i <= 2 * l)
                {
                    result.Add(i);
                    break;
                }
                else
                {
                    result.Add(l);
                    i -= l;
                }
            }
            return result;
        }
    }
}
