using Data.Data;
using System;

namespace Data.Map
{
    public class Obstacle : SearchArea
    {
        public Obstacle(int coornerX1, int coornerY1, int coornerX2, int coornerY2) : base(coornerX1, coornerY1, coornerX2, coornerY2)
        {
        }

        public static Obstacle GetObstacle(Position corner1, Position corner2)
        {
            var o = SearchArea.GetSearchArea(corner1, corner2) as Obstacle ?? throw new Exception("Conversion wasn't possible");
            return o;
        }
    }
}
