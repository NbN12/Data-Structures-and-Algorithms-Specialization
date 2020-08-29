using System;

namespace money_change_again
{
    class ChangeDP
    {
        private static readonly int[] coins = new int[] { 1, 3, 4 };
        static void Main(string[] args)
        {
            var m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{GetChange(m)}");
        }

        private static int GetChange(int m)
        {
            int[] minNumCoins = new int[m + 1];
            minNumCoins[0] = 0;
            for (int i = 1; i < m + 1; i++)
            {
                minNumCoins[i] = Int32.MaxValue;
                foreach (var coin in coins)
                {
                    if (i >= coin)
                    {
                        minNumCoins[i] = Math.Min(minNumCoins[i], minNumCoins[i - coin] + 1);
                    }
                }
            }
            return minNumCoins[m];
        }
    }
}
