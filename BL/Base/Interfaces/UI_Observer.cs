using Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Base.Interfaces
{
    public interface IObserver_RRT : IObserver<TreeLine>, IObserver<IEnumerable<TreeLine>>
    {
    }
}
