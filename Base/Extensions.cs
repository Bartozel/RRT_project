using RBush;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Base
{
    public static class Extensions
    {
        public static int AsInt(this double val)
        {
            return (int)Math.Floor(val);
        }

        public static Envelope GetNewEnvelope(this Position position)
        {
            var area = SearchArea.GetNodeArea(position);
            return new Envelope(area.MinX, area.MinY, area.MaxX, area.MaxY);
        }

        public static Envelope GetNewEnvelope(this SearchArea area)
        {
            if (area == null)
                throw new NullReferenceException();

            return new Envelope(area.MinX, area.MinY, area.MaxX, area.MaxY);
        }
    }
}
