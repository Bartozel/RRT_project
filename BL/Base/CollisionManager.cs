using Data;
using Data.Data;
using Data.Map;
using DiplomkaBartozel.Base.Agent;
using DiplomkaBartozel.Interfaces;
using DiplomkaBartozel.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Base
{
    class CollisionManager
    {
        public bool IsCollisionStaticObstacles(SearchArea sa)
        {
            bool res = false;
            foreach(var obstacle in MapManager.StaticObstales)
            {
                if (obstacle.Intersect(sa))
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public bool IsPathBetweenPointsFree(Position p1, Position p2)
        {
            
        }

        public bool IsCollisionDynamicObstacles(SearchArea sa)
        {
            bool res = false;
            foreach (var agent in AgentManager.AgentObstacles)
            {
                if (agent.Intersect(sa))
                {
                    res = true;
                    break;
                }
            }
            return res;
        }
    }
}
