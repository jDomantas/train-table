using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
