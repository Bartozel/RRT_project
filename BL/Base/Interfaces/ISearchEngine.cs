using DiplomkaBartozel.Base;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Interfaces
{
    public interface ISearchEngine
    {
        event EventHandler PathIsAvailable;
        event EventHandler PathIsBlocked;

        bool PathExist { get; }

        List<TreeLine> PathGoalToRoot();
        TreeLine GenerateNextStep();
    }
}
