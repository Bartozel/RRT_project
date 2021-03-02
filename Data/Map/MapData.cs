
using System.Collections.Generic;

namespace Data.Map
{
    public static class MapData
    {
        public static List<Obstacle> StaticObstacles { get; }

        public static void Add(Obstacle obstacle)
        {
            StaticObstacles.Add(obstacle);
        }
    }
}
