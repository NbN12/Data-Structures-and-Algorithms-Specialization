using System;

namespace money_change
{
    class Change
    {
        const int COIN_10 = 10;
        const int COIN_5 = 5;
        const int COIN_1 = 1;

        static void Main(string[] args)
        {
            var m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{GetChange(m)}");
        }

        private static int GetChange(int m)
        {
            int change = 0;

            while (m >= COIN_10)
            {
                ++change;
                m -= COIN_10;
            }

            while (m >= COIN_5)
            {
                ++change;
                m -= COIN_5;
            }

            while (m >= COIN_1)
            {
                ++change;
                m -= COIN_1;
            }
            return change;
        }
    }
}
