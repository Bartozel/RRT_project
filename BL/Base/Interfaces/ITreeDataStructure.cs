using Data.Data;
using DiplomkaBartozel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Interfaces
{
    interface ITreeDataStructure
    {
        void Insert(Node node);
        void BulkInsert(IEnumerable<Node> nodes);
        void Clear(Node node);
        void ClearAll();
        IEnumerable<Node> Search(SearchArea area);
        IEnumerable<Node> GetAllNodes();
        int NodeSum { get; }
    }
}
