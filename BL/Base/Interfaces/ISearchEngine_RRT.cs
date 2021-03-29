using Data.Data;
using System;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    interface ISearchEngine_RRT_STAR
    {
        event EventHandler NewPoint;

        IEnumerable<TreeLine> GetChangesFromRewire(Position position);
    }
}
