using System.Collections.Generic;
using System;

namespace primitive_calculator
{
    class PrimitiveCalculator
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var sequence = OptimalSequence(n);
            Console.WriteLine($"{sequence.Count - 1}");
            foreach (var item in sequence)
            {
                Console.Write($"{item} ");
            }
        }

        private static List<int> OptimalSequence(int n)
        {
            var genSequence = new int[n + 1];
            genSequence[0] = -1;
            genSequence[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                genSequence[i] = 1 + Min3(genSequence[i - 1], i % 2 == 0 ? genSequence[i / 2] : Int32.MaxValue, i % 3 == 0 ? genSequence[i / 3] : Int32.MaxValue);
            }
            var sequence = new List<int>();
            sequence.Add(n);
            while (n > 1)
            {
                if (n % 2 == 0 && genSequence[n] - 1 == genSequence[n / 2])
                    n /= 2;
                else if (n % 3 == 0 && genSequence[n] - 1 == genSequence[n / 3])
                    n /= 3;
                else
                    n -= 1;
                sequence.Add(n);
            }
            sequence.Reverse();
            return sequence;
        }

        private static int Min3(int a, int b, int c)
        {
            return Math.Min(Math.Min(a, b), c);
        }
    }
}
