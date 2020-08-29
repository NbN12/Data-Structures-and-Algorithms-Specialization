using System;

namespace maximum_value_of_an_arithmetic_expression
{
    class PlacingParentheses
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            Console.WriteLine($"{GetMaximumValue(s)}");
        }

        private static long GetMaximumValue(string str)
        {
            var numberOfOperands = (str.Length + 1) / 2;
            long[,] min = new long[numberOfOperands, numberOfOperands];
            long[,] max = new long[numberOfOperands, numberOfOperands];

            for (int i = 0; i < numberOfOperands; i++)
            {
                min[i, i] = Convert.ToInt64(str.Substring(2 * i, 1));
                max[i, i] = Convert.ToInt64(str.Substring(2 * i, 1));
            }

            for (int s = 0; s < numberOfOperands - 1; s++)
            {
                for (int i = 0; i < numberOfOperands - s - 1; i++)
                {
                    var j = i + s + 1;
                    long minValue = Int64.MaxValue;
                    long maxValue = Int64.MinValue;
                    for (int k = i; k < j; k++)
                    {
                        char op = str[2 * k + 1];
                        var a = Eval(min[i, k], min[k + 1, j], op);
                        var b = Eval(min[i, k], max[k + 1, j], op);
                        var c = Eval(max[i, k], min[k + 1, j], op);

                        var d = Eval(max[i, k], max[k + 1, j], op);

                        minValue = Math.Min(minValue, Min4(a, b, c, d));
                        maxValue = Math.Max(maxValue, Max4(a, b, c, d));

                    }
                    min[i, j] = minValue;
                    max[i, j] = maxValue;

                }
            }
            return max[0, numberOfOperands - 1];
        }

        private static long Eval(long a, long b, char op)
        {
            switch (op)
            {
                case '*':
                    return a * b;
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                default:
                    return 0;
            }
        }

        private static long Min4(long a, long b, long c, long d)
        {
            return Math.Min(a, Math.Min(b, Math.Min(c, d)));
        }
        private static long Max4(long a, long b, long c, long d)
        {
            return Math.Max(a, Math.Max(b, Math.Max(c, d)));
        }
    }
}
