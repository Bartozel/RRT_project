﻿using Data;
using System;

namespace SearchEngine
{
    //Not implemented. Maybe later. Implementation suited for specific envinronment
    class Informed_RRT_Star : RRT_STAR
    {
        public Informed_RRT_Star(IPosition startPos, IPosition goalPos) : base(startPos, goalPos)
        {
        }

        protected override IPosition GenerateNewPosition()
        {
            if (true)
            {
                var dist = _root.Distance(_goal);
                int width = GetPathWidth();

                IPosition pseudoPosition = GetPseudoPosition(dist, width);
                var res = Transform(pseudoPosition);

                return res;
            }
            else
                return base.GenerateNewPosition();
        }

        //move newly generated pseudo poin into real position between Goal and Root
        private IPosition Transform(IPosition pseudoPosition)
        {
            throw new NotImplementedException();
        }

        //Presume that Goal and Root are on X-axis. So generate point somewhere between those two points (x-coordinate) and path width, which we calculated earlier.
        private IPosition GetPseudoPosition(double dist, int width)
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

