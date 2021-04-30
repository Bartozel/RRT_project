using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class GlobalConfig
    {
        #region Tree
        public static int MaxEntries { get; } = 9;
        public static int GoalArea { get; } = 10;
        public const int MAX_DISTANCE = 40;
        #endregion

        #region Search
        public static int WidthOfSearchWindow { get; } = 750;
        public static int HeighOfSearchWindow { get; } = 550;
        public static int SearchAreaCenterToEdge { get; } = 3;
        #endregion
    }
}
