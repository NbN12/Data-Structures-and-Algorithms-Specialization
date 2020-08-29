using System;

namespace closest_points
{
    class Closest
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var x = new int[n];
            var y = new int[n];
            for (int i = 0; i < n; i++)
            {
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                x[i] = temp[0];
                y[i] = temp[1];
            }
            Console.WriteLine($"{MinimalDistance(x, y):#.#########}");
        }

        private static double MinimalDistance(int[] x, int[] y)
        {
            return 0.0;
        }
    }
}
