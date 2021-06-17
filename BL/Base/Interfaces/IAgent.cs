using Data.Data;
using System;
using System.Collections.Generic;
using Data.Enum;

namespace BL.Base.Interfaces
{
    public interface IAgent
    {
        Position GoalCoordinates { get; set; }
        Position RootCoordinates { get; set; }

        IObservable<Node> GetNewNodeObs(uint nodeCount);
        IObservable<Node> GetUpdateNodeObs();
        IObservable<List<Node>> GetPathToGoal();

        SearchState StopSearch();
        SearchState Pause();
        SearchState Restart();
    }
}
