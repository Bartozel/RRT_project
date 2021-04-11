using Data.Data;
using System;
using System.Collections.Generic;

namespace BL.Base.Interfaces
{
    interface ISearchEngine_RRT : ISearchEngine
    {
        IObservable<TreeLine> UpdateTree(Position position);

        IObservable<TreeLine> GenerateNextStep();

        void Subscript(IObserver_RRT observer);
    }
}
