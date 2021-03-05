﻿using Data;
using Data.Data;
using Data.Map;
using BL.Agent;
using System.Linq;

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
            return true; //TODO
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
