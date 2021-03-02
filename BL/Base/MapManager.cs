using Data.Data;
using Data.Map;
using DiplomkaBartozel.Base.Agent;
using System.Collections.Generic;

namespace Data.Map
{
    static class MapManager
    {
        public static List<Obstacle>  StaticObstales { get;  } = MapData.StaticObstacles;

        public static void CreateObstacle(Position corner1, Position corner2)
        {
            var o = Obstacle.GetObstacle(corner1, corner2);
            MapData.Add(o);
        } 

    }
}
