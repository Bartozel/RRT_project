using DiplomkaBartozel.Base;
using DiplomkaBartozel.Base.Agent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Map
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
