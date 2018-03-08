using System.Collections.Generic;
using System.Linq;

namespace Ford_Bellman
{
    public class Solver
    {

        public static string[] Solve(string[] input)
        {
            var size = int.Parse(input[0]);
            var weights = InitWeights(input);
            var solver = new FordBellman(size, weights);
            var start = int.Parse(input[input.Length - 2]) - 1;
            var end = int.Parse(input[input.Length - 1]) - 1;

            var path = solver.FindPath(start, end);
            if (Equals(path, Path.Empty)) return new[] {"N"};
            return new[]
            {
                "Y",
                string.Join(" ", path.Vertexs),
                path.Weight.ToString()
            };
        }

        private static int[][] InitWeights(IEnumerable<string> input)
        {
            var enumerable = input as string[] ?? input.ToArray();
            return enumerable
                .Skip(1)
                .Take(enumerable.Length - 3)
                .Select(s => s
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray())
                .ToArray();
        }
    }
}
