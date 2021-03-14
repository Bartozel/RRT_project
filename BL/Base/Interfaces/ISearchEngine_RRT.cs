using Data.Data;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    interface ISearchEngine_RRT_STAR
    {
        IEnumerable<TreeLine> GetChangesFromRewire(Position position);
    }
}
