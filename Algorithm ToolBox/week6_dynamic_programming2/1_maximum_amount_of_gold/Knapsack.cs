using System;

namespace maximum_amount_of_gold
{
    class Knapsack
    {
        static void Main(string[] args)
        {
            var temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var capacity = temp[0];
            var weights = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{OptimalWeight(capacity, weights)}");
        }
        private static int OptimalWeight(int capacity, int[] weights)
        {
            var value = new int[weights.Length + 1, capacity + 1];
            for (int i = 0; i <= capacity; i++)
                value[0, i] = 0;
            for (int i = 0; i <= weights.Length; i++)
                value[i, 0] = 0;
            for (int i = 1; i <= weights.Length; i++)
            {
                for (int w = 1; w <= capacity; w++)
                {
                    value[i, w] = value[i - 1, w];
                    if (weights[i - 1] <= w)
                    {
                        value[i, w] = Math.Max(value[i - 1, w - weights[i - 1]] + weights[i - 1], value[i - 1, w]);
                    }
                }
            }
            return value[weights.Length, capacity];
        }
    }
}
