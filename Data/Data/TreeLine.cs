using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class TreeLine
    {
        public Position Start { get; }
        public Position End { get; }

        public TreeLine(Position start, Position end)
        {
            Start = start;
            End = end;
        }
    }
}
