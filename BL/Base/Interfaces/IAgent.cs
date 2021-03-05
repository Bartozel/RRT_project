using Data.Data;
using DiplomkaBartozel.Base;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Interfaces
{
    interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        IDisposable SubscribeSearch(IObserver<TreeLine> observer);
        //IDisposable SubscribeMove(IObserver<TreeLine> observer);
        void StopSearch();
        void Pause();
        void Restart();
    }
}
