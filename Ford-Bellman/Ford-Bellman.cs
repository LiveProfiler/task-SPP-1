using System;
using System.Collections.Generic;
using System.Linq;

namespace Ford_Bellman
{
    public class FordBellman
    {
        private const int Inf = -32768;
        private static readonly double LogInf = Math.Log(-Inf);
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
                .Repeat(LogInf, size)
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
                        var weight = double.IsInfinity(Math.Log(weights[j][i])) ? LogInf : Math.Log(weights[j][i]);
                        if (dest[j] - weight < dest[i])
                        {
                            dest[i] = dest[j] - weight;
                            pref[i] = j;
                            stop = true;
                        }
                    }
                }
            }
            return FindPath(start, end, dest, pref);
        }

        private Path FindPath(int start, int end, IReadOnlyList<double> dest, IReadOnlyList<int> pref) 
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
