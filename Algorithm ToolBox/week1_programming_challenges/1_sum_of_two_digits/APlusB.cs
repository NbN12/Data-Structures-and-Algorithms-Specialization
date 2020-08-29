using System;

namespace APlusB
{
    class APlusB
    {
        static void Main(string[] args)
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var a = numbers[0];
            var b = numbers[1];
            Console.WriteLine($"{Add(a, b)}");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
