using System;
using System.Linq;

namespace majority_element
{
    class MajorityElement
    {
        static void Main(string[] args)
        {
            var n = Convert.ToInt32(Console.ReadLine());
            var a = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            if (GetMajorityElement(a, 0, a.Length) != -1)
                Console.WriteLine(1);
            else
                Console.WriteLine(0);
        }

        private static int GetMajorityElement(int[] a, int left, int right)
        {
            int majority_element = GetMajorityElementGenerator(a, left, right - 1);
            return a.Count(x => x == majority_element) > left + (right - left) / 2 ? 1 : -1;
        }

        private static int GetMajorityElementGenerator(int[] a, int left, int right)
        {
            if (left == right)
                return a[left];
            int mid = left + (right - left) / 2;

            int left_element = GetMajorityElementGenerator(a, left, mid);
            int right_element = GetMajorityElementGenerator(a, mid + 1, right);

            if (left_element == right_element)
                return left_element;
            int count_left = CountElement(a, left, right, left_element);
            int count_right = CountElement(a, left, right, right_element);
            return count_left > count_right ? left_element : right_element;
        }

        private static int CountElement(int[] a, int left, int right, int key)
        {
            int count = 0;
            for (int i = left; i <= right; ++i)
            {
                if (a[i] == key)
                    ++count;
            }
            return count;
        }
    }
}
