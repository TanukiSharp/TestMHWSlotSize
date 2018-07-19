using System;
using System.Collections.Generic;
using System.Linq;

namespace TestMHWSlotSize
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int[]>();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j > i)
                        continue;

                    for (int k = 0; k < 4; k++)
                    {
                        if (k > j)
                            continue;

                        var slots = new int[] { i, j, k };
                        list.Add(slots);
                    }
                }
            }

            var q = from slots in list
                    let score = Score(slots)
                    orderby score descending, slots.Count(x => x > 0) descending
                    select new { Score = score, Slots = slots };

            foreach (var x in q)
            {
                Console.WriteLine($"{string.Join("", x.Slots.Select(s => s == 0 ? "-" : s.ToString()))}  |  {x.Score}");
            }
        }

        private static int Score(int[] slots)
        {
            return slots.Sum(x => x * x);
            //return slots.Sum(x => x * x * x);
        }
    }
}
