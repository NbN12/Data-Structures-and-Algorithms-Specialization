using System.Linq;
using System;

namespace _1_binary_search
{
    class BinarySearch
    {
        static void Main(string[] args)
        {
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).Skip(1).ToArray();
            var b = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse).Skip(1).ToArray();
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write($"{BSearch(a, b[i])} ");
            }
        }

        private static int BSearch(int[] a, int key)
        {
            int left = 0, right = a.Length - 1;
            int mid;
            int result = -1;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (a[mid] == key)
                {
                    right = mid - 1;
                    result = mid;
                }
                else if (key > a[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return result;
        }
    }
}
