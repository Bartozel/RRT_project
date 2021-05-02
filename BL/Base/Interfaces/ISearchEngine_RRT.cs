using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading;

namespace BL.Base.Interfaces
{
    interface ISearchEngine_RRT : ISearchEngine
    {
        uint NodesCount { get; }
        IObservable<Node> UpdateTree();
        IObservable<Node> CreateNewNodeObs(uint amount, CancellationDisposable cancellationToken);
    }
}
