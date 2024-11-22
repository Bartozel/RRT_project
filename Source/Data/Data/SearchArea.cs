namespace Data
{
    public class SearchArea : Position
    {
        public int MaxX { get; }
        public int MinX { get; }
        public int MaxY { get; }
        public int MinY { get; }

        public SearchArea() : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cornerX1"></param>
        /// <param name="cornerY1"></param>
        /// <param name="cornerX2"></param>
        /// <param name="cornerY2"></param>
        public SearchArea(int cornerX1, int cornerY1, int cornerX2, int cornerY2) : this()
        {
            (int minX, int maxX) = Compare(cornerX1, cornerX2);
            (int minY, int maxY) = Compare(cornerY1, cornerY2);
            MinX = minX;
            MaxX = maxX;
            MinY = minY;
            MaxY = maxY;
        }

        public SearchArea(IPosition position) : base(position)
        {
            var area = GetSearchArea(position);
            MaxX = area.MaxX;
            MinX = area.MinX;
            MaxY = area.MaxY;
            MinY = area.MinY;
        }

        public static SearchArea GetSearchArea(IPosition position)
        {
            (int minX, int maxX) = GetXRange(position.XCoordinate);
            (int minY, int maxY) = GetYRange(position.YCoordinate);

            return new SearchArea(minX, minY, maxX, maxY);
        }

        private static (int minY, int maxY) GetYRange(int yCoordinate)
        {
            return GetRange(yCoordinate, GlobalConfig.SearchAreaYValue, GlobalConfig.SearchAreaCenterToEdge);
        }

        private static (int minX, int maxX) GetXRange(int xCoordinate)
        {
            return GetRange(xCoordinate, GlobalConfig.SearchAreaXValue, GlobalConfig.SearchAreaCenterToEdge);
        }

        private static (int minX, int maxX) GetRange(int coordinate, int rangeLimit, int shift)
        {
            int min, max;
            var temp = coordinate - shift;
            if (temp < 0)
                min = 0;
            else
                min = temp;

            temp = coordinate + shift;
            if (temp > rangeLimit)
                max = rangeLimit;
            else
                max = temp;

            return (min, max);
        }

        public static SearchArea GetSearchArea(IPosition p1, IPosition p2)
        {
            (int minX, int maxX) = Compare(p1.XCoordinate, p2.XCoordinate);
            (int minY, int maxY) = Compare(p1.YCoordinate, p2.YCoordinate);

            return new SearchArea(minX, maxX, minY, maxY);
        }

        private static (int min, int max) Compare(int val1, int val2)
        {
            if (val1 > val2)
                return (val2, val1);
            else
                return (val1, val2);
        }

        public static SearchArea GetSearchArea(IPosition position, int dist)
        {
            (int minX, int maxX) = GetRange(position.XCoordinate, GlobalConfig.SearchAreaXValue, dist);
            (int minY, int maxY) = GetRange(position.YCoordinate, GlobalConfig.SearchAreaYValue, dist);

            return new SearchArea(minX, minY, maxX, maxY);
        }

        public static SearchArea GetNearSearArea(IPosition position, int dist)
        {
            return GetSearchArea(position, dist);
        }
    }
}
