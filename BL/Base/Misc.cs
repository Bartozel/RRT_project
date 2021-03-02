using Data.Data;
using DiplomkaBartozel.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Base
{
    public static class Misc
    {
        public static double Distance(Position node1, Position node2)
        {
            return Math.Sqrt(Math.Pow(node1.XCoordinate - node2.XCoordinate, 2) + Math.Pow(node1.YCoordinate - node2.YCoordinate, 2));
        }

        //TODO test
        internal static (int newX, int newY) CalculateCloserPosition(SearchArea staticNode, SearchArea shiftNode, double currentDist, double maxDistance)
        {
            double shift = maxDistance / currentDist;
            var newX = (int)((1 - shift) * staticNode.MaxX + shift * shiftNode.MaxX);
            var newY = (int)((1 - shift) * staticNode.MaxY + shift * shiftNode.MaxY);

            return (newX, newY);
        }
    }
}
