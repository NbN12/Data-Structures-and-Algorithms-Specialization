using System;

namespace organizing_a_lottery
{
    class PointsAndSegments
    {

        private static int[] NaiveCountSegments(int[] starts, int[] ends, int[] points)
        {
            int[] cnt = new int[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < starts.Length; j++)
                {
                    if (starts[j] <= points[i] && points[i] <= ends[j])
                    {
                        cnt[i]++;
                    }
                }
            }
            return cnt;
        }

        static void Main(string[] args)
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = numbers[0];
            var starts = new int[n];
            var ends = new int[n];
            for (int i = 0; i < n; i++)
            {
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                starts[i] = temp[0];
                starts[i] = temp[1];
            }
            var points = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            var cnt = NaiveCountSegments(starts, ends, points);
            foreach (var item in cnt)
            {
                Console.Write($"{item} ");
            }
        }

        private static int[] FastCountSegments(int[] starts, int[] ends, int[] points)
        {
            var cnt = new int[points.Length];
            //write your code here
            return cnt;
        }
    }
}
