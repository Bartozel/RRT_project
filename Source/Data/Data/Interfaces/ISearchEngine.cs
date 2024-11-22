using System;
using System.Collections.Generic;

namespace Data
{
    public interface ISearchEngine
    {
        event EventHandler PathIsAvailable;
        event EventHandler PathIsBlocked;

        bool PathExists { get; }

        List<CanvasLine> PathGoalToRoot();
    }
}
