using DiplomkaBartozel.Base;
using DiplomkaBartozel.Base.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
