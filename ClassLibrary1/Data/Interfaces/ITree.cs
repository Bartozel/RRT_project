using System.Collections.Generic;

namespace Data.Data.Interfaces
{
    public interface ITree
    {
        ITreeNode Root { get; }
        int Count { get; }
        bool Insert(ITreeNode node);
        bool BulkInsert(ITreeNode[] nodes);
        void Clear(ITreeNode node);
        void ClearAll();
        IEnumerable<ITreeNode> GetNodesFromSearchArea(SearchArea area);
    }
}
