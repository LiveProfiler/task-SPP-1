using System.Collections.Generic;

namespace Ford_Bellman
{
    public class Path
    {
        public static readonly Path Empty = new Path(new List<int>(), 0);

        public readonly IEnumerable<int> Vertexs;
        public readonly int Weight;

        public Path(IEnumerable<int> vertexs, int weight)
        {
            Vertexs = vertexs;
            Weight = weight;
        }

        protected bool Equals(Path other)
        {
            return Equals(Vertexs, other.Vertexs) && Weight == other.Weight;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Path) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Vertexs != null ? Vertexs.GetHashCode() : 0) * 397) ^ Weight;
            }
        }
    }
}