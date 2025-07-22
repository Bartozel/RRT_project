namespace Data
{
    public class Area : Position
    {
        public int MaxX { get; }
        public int MinX { get; }
        public int MaxY { get; }
        public int MinY { get; }

        public Area() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cornerX1"></param>
        /// <param name="cornerY1"></param>
        /// <param name="cornerX2"></param>
        /// <param name="cornerY2"></param>
        public Area(int cornerX1, int cornerY1, int cornerX2, int cornerY2) : this()
        {

        }
    }
}
