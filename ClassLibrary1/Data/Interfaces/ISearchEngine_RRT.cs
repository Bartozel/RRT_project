using System;
using System.Reactive.Disposables;

namespace Data.Data.Interfaces
{
    public interface ISearchEngine_RRT : ISearchEngine
    {
        int NodesCount { get; }
        IObservable<ITreeNode> UpdateTree();
        IObservable<ITreeNode> CreateNewNodeObs(uint amount, CancellationDisposable cancellationToken);
    }
}
