using Data.Data;
using System;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    public interface ISearchEngine
    {
        event EventHandler PathIsAvailable;
        event EventHandler PathIsBlocked;

        bool PathExists { get; }

        List<TreeLine> PathGoalToRoot();
    }
}
