using System;

namespace Data
{
    public class Obstacle : Area
    {
        public Obstacle(int cornerX1, int cornerY1, int cornerX2, int cornerY2) : base(cornerX1, cornerY1, cornerX2, cornerY2)
        {
        }

        public static Obstacle GetObstacle(IPosition corner1, IPosition corner2)
        {
            var o = Area.GetSearchArea(corner1, corner2) as Obstacle ?? throw new Exception("Conversion wasn't possible");
            return o;
        }
    }
}
