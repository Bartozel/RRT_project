using Data.Data;
using System;

namespace BL.Base.Interfaces
{
    public interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        IObservable<Node> GetNewNodeObs(uint nodeCount);
        IObservable<Node> GetUpdateNodeObs();

        void StopSearch();
        void Pause();
        void Restart();
    }
}
