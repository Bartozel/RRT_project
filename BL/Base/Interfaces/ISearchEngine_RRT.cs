using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading;

namespace BL.Base.Interfaces
{
    interface ISearchEngine_RRT : ISearchEngine
    {
        int NodesCount { get; }
        IObservable<ITreeNode> UpdateTree();
        IObservable<ITreeNode> CreateNewNodeObs(uint amount, CancellationDisposable cancellationToken);
    }
}
