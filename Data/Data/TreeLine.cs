using System.Drawing;

namespace Data.Data
{
    public class TreeLine
    {
        public Position Start { get; }
        public Position End { get; }
        public Color Color { get; }
        public int Width { get; }

        public TreeLine(Position start, Position end)
        {
            Start = start;
            End = end;
            Color = Color.Black;
            Width = 2;
        }

        public TreeLine(Position start, Position end, Color color, int width)
        {
            Start = start;
            End = end;
            Color = color;
            Width = width;
        }
    }
}
