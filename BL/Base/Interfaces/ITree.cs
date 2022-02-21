using Data.Data;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    interface ITree
    {
        ITreeNode Root { get; }
        int Count { get; }
        bool Insert(ITreeNode node);
        bool BulkInsert(IEnumerable<ITreeNode> nodes);
        void Clear(ITreeNode node);
        void ClearAll();
        IEnumerable<ITreeNode> Search(SearchArea area);
    }
}
