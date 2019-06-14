using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainTable.Utils
{
    public static class ListUtils
    {
        public static void Shuffle<T>(this List<T> items, Random random)
        {
            for (int i = 0; i < items.Count; i++)
            {
                int swap = random.Next(i + 1);
                var x = items[swap];
                items[swap] = items[i];
                items[i] = x;
            }
        }

        public static double StandardDeviation(this IEnumerable<double> items)
        {
            var avg = items.Average();
            return Math.Sqrt(items.Select(i => avg - i).Select(i => i * i).Sum() / (items.Count() - 1));
        }
    }
}
