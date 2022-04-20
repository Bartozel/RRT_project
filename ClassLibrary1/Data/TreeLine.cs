using System.Drawing;

namespace Data.Data
{
    public class TreeLine
    {
        public IPosition Start { get; }
        public IPosition End { get; }
        public Color Color { get; }
        public int Width { get; }

        public TreeLine(IPosition start, IPosition end)
        {
            Start = start;
            End = end;
            Color = Color.Black;
            Width = 2;
        }

        public TreeLine(IPosition start, IPosition end, Color color, int width)
        {
            Start = start;
            End = end;
            Color = color;
            Width = width;
        }
    }
}
