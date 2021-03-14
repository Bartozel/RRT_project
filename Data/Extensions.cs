﻿using Data.Data;
using RBush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Extensions
    {
        public static int AsInt(this double val)
        {
            return (int)Math.Floor(val);
        }

        public static Envelope GetNewEnvelope(this Position position)
        {
            var area = SearchArea.GetSearchArea(position);
            return new Envelope(area.MinX, area.MinY, area.MaxX, area.MaxY);
        }

        public static Envelope ToEnvelope(this SearchArea area)
        {
            if (area == null)
                throw new NullReferenceException();

            return new Envelope(area.MinX, area.MinY, area.MaxX, area.MaxY);
        }

        public static bool Intersect(this SearchArea sa1, SearchArea sa2)
        {
            if (sa1.MaxX > sa2.MinX && sa1.MinX < sa2.MaxX && sa1.MaxY > sa2.MinY && sa1.MinY < sa2.MinY)
                return true;

            return false;
        }

        public static TreeLine ToLine(this Node node)
        {
            return new TreeLine(node, node.Parent);
        }

        public static IEnumerable<TreeLine> ToLine(this IEnumerable<Node> nodes)
        {
            return nodes.Select(node=> new TreeLine(node, node.Parent));
        }
    }
}
