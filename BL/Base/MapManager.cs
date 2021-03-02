using Data.Data;
using Data.Map;
using DiplomkaBartozel.Base.Agent;
using System.Collections.Generic;

namespace Data.Map
{
    static class MapManager
    {
        public static List<Obstacle> GetStaticObstales()
        {
            return MapData.StaticObstacles;
        }

        public static List<AgentObstacle> GetAgentObstacles()
        {

        }

        public static void CreateObstacle(Position min, Position max)
        {
            var sa = new SearchArea()
            MapData.Insert();
        } 

    }
}
