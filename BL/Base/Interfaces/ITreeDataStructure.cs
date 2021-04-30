using Data.Data;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    interface ITreeDataStructure
    {
        uint Count { get;}
        void Insert(Node node);
        void BulkInsert(IEnumerable<Node> nodes);
        void Clear(Node node);
        void ClearAll();
        IEnumerable<Node> Search(SearchArea area);
        IEnumerable<Node> GetAllNodes();
    }
}
