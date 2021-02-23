using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Base
{
    public static class GlobalConfig
    {
        #region Tree
        public static int MaxEntries { get; } = 9;
        public static int GoalArea { get; } = 10;
        public static int maxDist { get; } = 25;
        #endregion

        #region Search
        public static int WidthOfSearchArea { get; } = 750;
        public static int HeighOfSearchArea { get; } = 800;
        #endregion
    }
}
