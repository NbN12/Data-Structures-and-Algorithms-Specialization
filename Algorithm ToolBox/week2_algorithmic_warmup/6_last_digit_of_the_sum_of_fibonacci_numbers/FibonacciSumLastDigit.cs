using System;

namespace last_digit_of_the_sum_of_fibonacci_numbers
{
    class FibonacciSumLastDigit
    {
        // cache variable(s)
        private static readonly int PISANO_10_LEN = 60;
        static void Main(string[] args)
        {
            var n = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"{GetFibonacciSumLastDigit(n)}");
        }

        private static int GetFibonacciSumLastDigit(long n)
        {
            n = (n + 2) % PISANO_10_LEN;
            int f1 = 0, f2 = 1, temp;
            for (int i = 2; i <= n; ++i)
            {
                temp = (f1 + f2) % 10;
                f1 = f2;
                f2 = temp;
            }
            return f2 == 0 ? 9 : f2 - 1;
        }
    }
}
