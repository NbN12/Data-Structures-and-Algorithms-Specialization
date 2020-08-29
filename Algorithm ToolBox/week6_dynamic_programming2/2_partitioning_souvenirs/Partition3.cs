using System;

namespace partitioning_souvenirs
{
    class Partition3
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{GetPartition3(A)}");
        }

        private static int GetPartition3(object a)
        {
            throw new NotImplementedException();
        }
    }
}
