using System.Linq;
using System;
using System.Collections.Generic;

namespace collecting_signatures
{
    struct Segment
    {
        public int Start { get; set; }
        public int End { get; set; }
    }

    class CoveringSegments
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            Segment[] segments = new Segment[n];
            for (int i = 0; i < n; i++)
            {
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                segments[i].Start = temp[0];
                segments[i].End = temp[1];
            }
            var points = OptimalPoints(segments);
            Console.WriteLine($"{points.Count}");
            foreach (var p in points)
            {
                Console.Write($"{p} ");
            }
        }

        private static List<int> OptimalPoints(Segment[] segments)
        {
            List<int> points = new List<int>();
            segments = segments.OrderBy(s => s.End).ToArray();
            var pt = segments[0].End;
            points.Add(pt);
            for (int i = 1; i < segments.Length; i++)
            {
                if (pt < segments[i].Start || pt > segments[i].End)
                {
                    pt = segments[i].End;
                    points.Add(pt);
                }
            }
            return points;
        }
    }
}
