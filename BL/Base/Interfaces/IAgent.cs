using Data.Data;
using System;

namespace BL.Base.Interfaces
{
    interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        void SubscribeSearch(IObserver_RRT observer);
        void StopSearch();
        void Pause();
        void Restart();
    }
}
