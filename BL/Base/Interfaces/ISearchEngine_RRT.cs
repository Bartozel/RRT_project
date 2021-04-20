using Data.Data;
using System;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    interface ISearchEngine_RRT : ISearchEngine
    {
        IObservable<Node> UpdateTree();
        IObservable<Node> CreateNewNodeObs(int amount);
    }
}
