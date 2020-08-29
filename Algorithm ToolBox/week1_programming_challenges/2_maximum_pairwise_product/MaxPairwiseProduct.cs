using System;

namespace max_pairwise_product
{
    class MaxPairwiseProduct
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine($"{GetMaxPairwiseProduct(ref numbers)}");
        }

        static long GetMaxPairwiseProduct(ref int[] numbers)
        {
            int index1 = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[index1])
                    index1 = i;
            }
            int index2 = index1 == 0 ? 1 : 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[index2] && i != index1)
                    index2 = i;
            }
            return (long)numbers[index1] * (long)numbers[index2];
        }
    }
}
