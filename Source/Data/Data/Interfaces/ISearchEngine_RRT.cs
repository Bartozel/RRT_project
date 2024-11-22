using System;

namespace Data
{
    public interface ISearchEngine_RRT : ISearchEngine
    {
        int NodesCount { get; }
        ITreeNode UpdateTree();
        ITreeNode GenerateNewNode();
    }
}
