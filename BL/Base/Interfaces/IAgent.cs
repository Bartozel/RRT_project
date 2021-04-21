using Data.Data;
using System;

namespace BL.Base.Interfaces
{
    interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        IObservable<Node> GetNewNodeObs { get; }
        IObservable<Node> GetUpdateNodeObs { get; }

        void StopSearch();
        void Pause();
        void Restart();
    }
}
