using System;

namespace fibonacci_number_again
{
    class FibonacciHuge
    {
        static void Main(string[] args)
        {
            var temp = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var n = temp[0];
            var m = temp[1];
            Console.WriteLine($"{getFibonacciHuge(n, m)}");
        }

        private static long getPisanoPeriod(long m)
        {
            long pre = 0;
            long cur = 1;
            long bound = m * m;
            long temp = pre;

            for (long i = 0; i < bound; ++i)
            {
                temp = (pre + cur) % m;
                pre = cur;
                cur = temp;
                if (pre == 0 && cur == 1)
                    return i + 1;
            }
            return 1;
        }

        private static long getFibonacciHuge(long n, long m)
        {
            n %= getPisanoPeriod(m);

            long f1 = 0;
            long f2 = 1;
            long temp = f1;

            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;

            for (int i = 0; i < n - 1; i++)
            {
                temp = (f1 + f2) % m;
                f1 = f2;
                f2 = temp;
            }
            return f2 % m;
        }
    }
}
