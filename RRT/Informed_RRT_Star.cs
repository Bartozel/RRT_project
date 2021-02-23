using DiplomkaBartozel.Base;
using DiplomkaBartozel.Base.Data;
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
                var dist = Distance(this.root, this.goal);
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
            throw new NotImplementedException();
        }

        private Position GetPseudoPosition(double dist, int width)
        {
            throw new NotImplementedException();
        }

        private int GetPathWidth()
        {
            throw new NotImplementedException();
        }
    }

}

