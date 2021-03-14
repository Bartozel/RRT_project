using Data.Data;
using System;

namespace BL.Base.Interfaces
{
    interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        IDisposable SubscribeSearch(IObserver_UI observer);
        void StopSearch();
        void Pause();
        void Restart();
    }
}
