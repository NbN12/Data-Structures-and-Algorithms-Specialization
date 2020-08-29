using System;

namespace greatest_common_divisor
{
    class Gcd
    {
        static void Main(string[] args)
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{GetGcd(numbers[0], numbers[1])}");
        }

        private static int GetGcd(int a, int b)
        {
            int rd;
            while (b > 0)
            {
                rd = a % b;
                a = b;
                b = rd;
            }
            return a;
        }
    }
}
