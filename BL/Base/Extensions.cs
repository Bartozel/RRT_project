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

    }
}
