using System;

namespace improving_quicksort
{
    class Sorting
    {
        private static readonly Random random = new Random();
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());

            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            RandomizedQuickSort(ref a, 0, a.Length - 1);
            foreach (var item in a)
            {
                Console.Write($"{item} ");
            }
        }

        private static void RandomizedQuickSort(ref int[] a, int left, int right)
        {

            if (left >= right)
                return;
            int k = random.Next(left, right + 1);
            Swap(ref a[right], ref a[k]);
            int m1 = 0;
            int m2 = 0;
            Partition3(ref a, left, right, ref m1, ref m2);
            RandomizedQuickSort(ref a, left, m1);
            RandomizedQuickSort(ref a, m2, right);

        }

        private static void Partition3(ref int[] a, int left, int right, ref int m1, ref int m2)
        {
            if (right - left <= 1)
            {
                if (a[right] < a[left])
                    Swap(ref a[right], ref a[left]);
                m1 = left;
                m2 = right;
                return;
            }

            int mid = left;
            int pivot = a[right];
            while (mid <= right)
            {
                if (a[mid] < pivot)
                    Swap(ref a[left++], ref a[mid++]);
                else if (a[mid] == pivot)
                    mid++;
                else if (a[mid] > pivot)
                    Swap(ref a[mid], ref a[right--]);
            }
            m1 = left - 1;
            m2 = mid;
        }

        private static void Swap<T>(ref T v1, ref T v2)
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
