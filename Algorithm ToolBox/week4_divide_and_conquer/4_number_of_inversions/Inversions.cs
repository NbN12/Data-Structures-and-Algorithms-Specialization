using System;

namespace number_of_inversions
{
    class Inversions
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var b = new int[a.Length];
            Console.WriteLine($"{GetNumberOfInversions(ref a, b, 0, a.Length - 1)}");
        }

        private static long GetNumberOfInversions(ref int[] a, int[] b, int left, int right)
        {
            long countInv = 0;
            if (left < right)
            {
                var mid = left + (right - left) / 2;
                countInv += GetNumberOfInversions(ref a, b, left, mid);
                countInv += GetNumberOfInversions(ref a, b, mid + 1, right);
                countInv += MergeCount(ref a, b, left, mid + 1, right);
            }
            return countInv;
        }

        private static long MergeCount(ref int[] a, int[] b, int left, int mid, int right)
        {
            int i = left, j = mid, k = left;
            long countInv = 0;
            while ((i <= mid - 1) && (j <= right))
            {
                if (a[i] <= a[j])
                {
                    b[k++] = a[i++];
                }
                else
                {
                    b[k++] = a[j++];
                    countInv = countInv + (mid - i);
                }
            }

            while (i <= mid - 1)
                b[k++] = a[i++];

            while (j <= right)
                b[k++] = a[j++];

            for (i = left; i <= right; i++)
                a[i] = b[i];

            return countInv;
        }
    }
}
