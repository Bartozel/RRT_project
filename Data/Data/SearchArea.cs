using DiplomkaBartozel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
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

        public SearchArea(int xMin, int xMax, int yMin, int yMax) : this()
        {
            MinX = xMin;
            MaxX = xMax;
            MinY = yMin;
            MaxY = yMax;
        }

        public static SearchArea GetSearchArea(Position position)
        {
            (int minX, int maxX) = GetXRange(position.XCoordinate);
            (int minY, int maxY) = GetYRange(position.YCoordinate);

            return new SearchArea(minX, maxX, minY, maxY);
        }

        private static (int minY, int maxY) GetYRange(int yCoordinate)
        {
            return GetRange(yCoordinate, GlobalConfig.WidthOfSearchWindow, GlobalConfig.SearchAreaCenterToEdge);
        }

        private static (int minX, int maxX) GetXRange(int xCoordinate)
        {
            return GetRange(xCoordinate, GlobalConfig.HeighOfSearchWindow, GlobalConfig.SearchAreaCenterToEdge);
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

        public static SearchArea GetSearchArea(Position p1, Position p2)
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

        public static SearchArea GetSearchArea(Position position, int dist)
        {
            (int minX, int maxX) = GetRange(position.XCoordinate, GlobalConfig.WidthOfSearchWindow, dist);
            (int minY, int maxY) = GetRange(position.YCoordinate, GlobalConfig.HeighOfSearchWindow, dist);

            return new SearchArea(minX, maxX, minY, maxY);
        }

        public static SearchArea GetSearchNearArea(Position position)
        {
            int dist = GlobalConfig.NearAreaCenterToEdge;
            return GetSearchArea(position, dist);
        }
    }
}
