using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public static class Extensions
    {
        public static int AsInt(this double val)
        {
            return (int)Math.Floor(val);
        }

        public static bool Intersect(this SearchArea sa1, SearchArea sa2)
        {
            if (sa1.MaxX > sa2.MinX && sa1.MinX < sa2.MaxX && sa1.MaxY > sa2.MinY && sa1.MinY < sa2.MinY)
                return true;

            return false;
        }

        public static CanvasLine ToLine(this ITreeNode node)
        {
            return new CanvasLine(node, node.Parent);
        }

        public static IEnumerable<CanvasLine> ToLine(this IEnumerable<ITreeNode> nodes)
        {
            return nodes.Select(node=> new CanvasLine(node, node.Parent));
        }
    }
}
