namespace Data.Search
{
    public interface IRrtSearchEngine : ISearchEngine
    {
        int NodesCount { get; }
        SearchTreeNode UpdateTree();
        SearchTreeNode GenerateNewNode();
    }
}
