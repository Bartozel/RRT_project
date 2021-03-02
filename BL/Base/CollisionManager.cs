using Data;
using Data.Data;
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
        public bool IsCollisionWithStaticObstacles(SearchArea sa)
        {
            bool res = false;
            foreach(var obstacle in )
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

        public bool IsInCollisionDynamicObstacles(SearchArea position)
        {
            
        }
    }
}
