using System.Drawing;

namespace Data
{
    public class CanvasLine
    {
        public IPosition Start { get; }
        public IPosition End { get; }
        public Color Color { get; }
        public int Width { get; }

        public CanvasLine(IPosition start, IPosition end)
        {
            Start = start;
            End = end;
            Color = Color.Black;
            Width = 2;
        }

        public CanvasLine(IPosition start, IPosition end, eColor color, int width)
        {
            Start = start;
            End = end;
            //Color = color;
            Width = width;
        }
    }
}
