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

        public SearchArea(int xCoordinate, int width, int yCoordinate, int height) : base()
        {
            MaxX = xCoordinate;
            MinX = width;

            MaxY = yCoordinate;
            MinY = height;
        }

        public SearchArea(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
            var area = GetNodeArea(new Position(xCoordinate, yCoordinate));
            MaxX = area.MaxX;
            MinX = area.MinX;

            MaxY = area.MaxY;
            MinY = area.MinY;
        }


        public SearchArea(Position position) : base(position)
        {
            var area = GetNodeArea(position);
            MaxX = area.MaxX;
            MinX = area.MinX;

            MaxY = area.MaxY;
            MinY = area.MinY;
        }

        public static SearchArea GetNodeArea(Position position)
        {
            throw new NotImplementedException();
        }

        public static SearchArea GetNodeNearArea(Position position)
        {
            throw new NotImplementedException();
        }

        private static SearchArea GetNodeArea(Position position, int dist)
        {
            throw new NotImplementedException();
        }
    }
}
