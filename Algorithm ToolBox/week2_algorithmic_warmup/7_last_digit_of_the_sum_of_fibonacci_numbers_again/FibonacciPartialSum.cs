using System;

namespace last_digit_of_the_sum_of_fibonacci_numbers_again
{
    class FibonacciPartialSum
    {
        // cache preference
        private static readonly int PISANO_10_LEN = 60;
        private static int[] pisanoPeriod;
        public static void Main(string[] args)
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var from = numbers[0];
            var to = numbers[1];
            FillPisanoPeriod();
            Console.WriteLine($"{FibonacciPartialSum(from, to)}");
        }

        private static void FillPisanoPeriod()
        {
            pisanoPeriod = new int[PISANO_10_LEN];
            for (int i = 0; i < PISANO_10_LEN; ++i)
            {
                if (i <= 1)
                    pisanoPeriod[i] = i;
                else
                    pisanoPeriod[i] = (pisanoPeriod[i - 2] + pisanoPeriod[i - 1]) % 10;
            }
        }

        private static int FibonacciPartialSum(long from, long to)
        {
            from %= PISANO_10_LEN;
            to %= PISANO_10_LEN;
            to += from > to ? 60 : 0;
            int sum = 0;
            for (long i = from; i <= to; ++i)
            {
                sum += pisanoPeriod[i % 60];
                sum %= 10;
            }
            return sum;
        }
    }
}