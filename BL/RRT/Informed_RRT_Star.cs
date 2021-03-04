using BL.Base;
using Data.Data;
using DiplomkaBartozel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomkaBartozel.RRT
{
    class Informed_RRT_Star : RRT_STAR
    {
        public Informed_RRT_Star(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
        }

        protected override Node GenerateNewNode()
        {
            if (this.PathExist)
            {
                var dist = Misc.Distance(this.root, this.goal);
                int width = GetPathWidth();

                Position pseudoPosition = GetPseudoPosition(dist, width);
                var res = Transform(pseudoPosition);

                return res;
            }
            else
                return base.GenerateNewNode();
        }

        private Node Transform(Position pseudoPosition)
        {
        }

        private Position GetPseudoPosition(double dist, int width)
        {
        }

        private int GetPathWidth()
        {
        }
    }

}

