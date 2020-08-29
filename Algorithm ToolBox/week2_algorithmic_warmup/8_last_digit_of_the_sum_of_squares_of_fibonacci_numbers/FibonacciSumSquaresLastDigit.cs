using System;

namespace last_digit_of_the_sum_of_squares_of_fibonacci_numbers
{
    class FibonacciSumSquaresLastDigit
    {
        // cache variable(s)
        private static readonly int PISANO_10_LEN = 60;
        private static int[] pisanoPeriod;

        static void Main(string[] args)
        {
            var n = Convert.ToInt64(Console.ReadLine());
            FillPisanoPeriod();
            Console.WriteLine($"{FibonacciSumSquares(n)}");
        }

        private static void FillPisanoPeriod()
        {
            pisanoPeriod = new int[PISANO_10_LEN + 1];
            for (int i = 0; i <= PISANO_10_LEN; i++)
            {
                if (i <= 1)
                    pisanoPeriod[i] = i;
                else
                    pisanoPeriod[i] = (pisanoPeriod[i - 2] + pisanoPeriod[i - 1]) % 10;
            }
        }

        private static int FibonacciSumSquares(long n)
        {
            n %= PISANO_10_LEN;
            return (pisanoPeriod[n] * pisanoPeriod[n + 1]) % 10;
        }
    }
}
