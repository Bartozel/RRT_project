using Data.Data;
using System;
using System.Collections.Generic;

namespace Data.Data.Interfaces
{
    public interface ISearchEngine
    {
        event EventHandler PathIsAvailable;
        event EventHandler PathIsBlocked;

        bool PathExists { get; }

        List<TreeLine> PathGoalToRoot();
    }
}
