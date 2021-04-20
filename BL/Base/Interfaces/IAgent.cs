using Data.Data;
using System;

namespace BL.Base.Interfaces
{
    interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        void StopSearch();
        IObservable<Node> StartSearch();
        void Pause();
        void Restart();
    }
}
