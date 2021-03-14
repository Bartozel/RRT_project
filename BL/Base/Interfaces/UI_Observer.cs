using Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Base.Interfaces
{
    public interface IObserver_UI : IObserver<TreeLine>, IObserver<IEnumerable<TreeLine>>
    {
        void Add(TreeLine treeLine);
        void Update(IEnumerable<TreeLine> treeLines);
    }
}
