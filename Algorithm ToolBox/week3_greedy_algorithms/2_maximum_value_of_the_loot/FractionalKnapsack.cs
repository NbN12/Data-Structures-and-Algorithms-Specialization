using System.Linq;
using System;

namespace maximum_value_of_the_loot
{
    class WeightAndValue
    {
        public WeightAndValue(int weight, int value)
        {
            this.Weight = weight;
            this.Value = value;
        }
        public int Weight { get; set; }
        public int Value { get; set; }
    }

    class FractionalKnapsack
    {
        static void Main(string[] args)
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            var capacity = numbers[1];
            var n = numbers[0];
            WeightAndValue[] weightAndValues = new WeightAndValue[n];
            int i = -1;
            while (++i < n)
            {
                var temp = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                weightAndValues[i] = new WeightAndValue(temp[0], temp[1]);
            }

            Console.WriteLine($"{GetOptimalValue(capacity, weightAndValues):0.0000}");
        }

        static double GetOptimalValue(int capacity, WeightAndValue[] weightAndValues)
        {
            double result = 0;
            if (capacity > 0)
            {
                int minWeight;
                double weightPerValue;
                weightAndValues = weightAndValues.OrderBy(x => (double)x.Value / x.Weight).ToArray();
                foreach (var item in weightAndValues)
                {
                    minWeight = Math.Min(item.Value, capacity);
                    weightPerValue = (double)item.Weight / item.Value;
                    result += weightPerValue * minWeight;
                    item.Value -= minWeight;
                    capacity -= minWeight;
                }
            }
            return result;
        }
    }
}
