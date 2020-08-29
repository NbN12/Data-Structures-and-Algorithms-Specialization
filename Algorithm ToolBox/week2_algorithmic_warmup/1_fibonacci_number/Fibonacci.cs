using System;

namespace fibonacci_number
{
    class Fibonacci
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{GetFibonacciNth(n)}");
        }

        static int GetFibonacciNth(int n)
        {
            if (n <= 1)
                return n;
            int f1 = 0, f2 = 1;
            int temp = 0;
            for (int i = 2; i <= n; i++)
            {
                temp = f1 + f2;
                f1 = f2;
                f2 = temp;
            }
            return f2;
        }
    }
}
