﻿using BL.Base;
using Data.Data;
using System;

namespace DiplomkaBartozel.RRT
{
    //Not implemented. Maybe later. Implementation suited for specific envinronment
    class Informed_RRT_Star : RRT_STAR
    {
        public Informed_RRT_Star(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
        }

        protected override Position GenerateNewPosition()
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
                return base.GenerateNewPosition();
        }

        //move newly generated pseudo poin into real position between Goal and Root
        private Position Transform(Position pseudoPosition)
        {
            throw new NotImplementedException();
        }

        //Presume that Goal and Root are on X-axis. So generate point somewhere between those two points (x-coordinate) and path width, which we calculated earlier.
        private Position GetPseudoPosition(double dist, int width)
        {
            throw new NotImplementedException();
        }

        //get greatest distance between Path and line/axis between Goal and Root
        private int GetPathWidth()
        {
            throw new NotImplementedException();
        }
    }

}

