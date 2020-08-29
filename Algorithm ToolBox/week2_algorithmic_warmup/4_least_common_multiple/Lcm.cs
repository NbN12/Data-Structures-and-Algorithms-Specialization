using System;

namespace least_common_multiple
{
    class Lcm
    {
        static void Main(string[] args)
        {
            var temp = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
            var a = temp[0];
            var b = temp[1];
            Console.WriteLine($"{getLcm(a, b)}");
        }

        private static long getLcm(long a, long b) => a / getGcd(a, b) * b;

        private static long getGcd(long a, long b)
        {
            long rd;
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
