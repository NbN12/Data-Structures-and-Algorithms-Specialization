using System;

namespace car_fueling
{
    class CarFueling
    {
        static void Main(string[] args)
        {
            var d = Convert.ToInt32(Console.ReadLine());
            var m = Convert.ToInt32(Console.ReadLine());
            var n = Convert.ToInt32(Console.ReadLine());

            var stops = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{ComputeMinRefills(d, m, stops)}");
        }

        private static int ComputeMinRefills(int dist, int tank, int[] stops)
        {
            int numRefills = 0, currentRefill = -1, lastRefill = 0;
            int n = stops.Length;
            while (currentRefill < n)
            {
                lastRefill = currentRefill;

                while (currentRefill < n && ((currentRefill + 1 >= stops.Length ? dist : stops[currentRefill + 1]) - (lastRefill == -1 ? 0 : stops[lastRefill])) <= tank)
                {
                    ++currentRefill;
                }
                if (currentRefill == lastRefill)
                    return -1;
                if (currentRefill < n)
                    ++numRefills;
            }
            return numRefills;
        }
    }
}
