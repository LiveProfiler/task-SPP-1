using System;
using System.Collections.Generic;
using System.Linq;

namespace Ford_Bellman
{
    public class FordBellman
    {
        private const int Inf = -32768;
        private readonly int[][] weights;
        private readonly int size;

        public FordBellman(int size, int[][] weights)
        {
            this.size = size;
            this.weights = weights; //TODO: need copy
        }

        public Path FindPath(int start, int end)
        {
            var dest = Enumerable
                .Repeat(-Inf, size)
                .ToArray();
            var pref = Enumerable
                .Repeat(-1, size)
                .ToArray();
            dest[start] = 0;
            var stop = false;
            for (var k = 1; k < size && !stop; ++k)
            {
                for (var i = 0; i < size; ++i)
                {
                    for (var j = 0; j < size; ++j)
                    {
                        if (dest[j] - weights[j][i] < dest[i])
                        {
                            dest[i] = Math.Min(-weights[j][i], dest[j] - weights[j][i]);
                            pref[i] = j;
                            stop = true;
                        }
                    }
                }
            }
            return FindPath(start, end, dest, pref);
        }

        private Path FindPath(int start, int end, IReadOnlyList<int> dest, IReadOnlyList<int> pref) 
        {
            if (dest[end] > 0) return Path.Empty;
            var path = new List<int>();
            var weight = 1;
            for (int current = end, prev = -1; current != -1; prev = current, current = pref[current])
            {
                path.Add(current);
                if (prev != -1)
                {
                    weight *= weights[current][prev];
                }
            }

            path = path.Select(x => x + 1).Reverse().ToList();
            return new Path(path, weight);
        }
    }
}
