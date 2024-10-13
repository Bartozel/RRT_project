﻿using System.Collections.Generic;

namespace Data
{
    public static class MapData
    {
        public static List<Obstacle> StaticObstacles { get; }

        static MapData()
        {
            StaticObstacles = new List<Obstacle>();
        }

        public static void Add(Obstacle obstacle)
        {
            StaticObstacles.Add(obstacle);
        }

        public static void Insert(SearchArea sa)
        {
            
        }
    }
}
