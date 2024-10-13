using System;
using System.Collections.Generic;

namespace Data
{
    public interface IAgent
    {
        IPosition GoalCoordinates { get; set; }
        IPosition RootCoordinates { get; set; }

        IObservable<ITreeNode> GetNewNodesObservable(uint nodeCount);
        IObservable<ITreeNode> GetUpdateNodeObs();
        IObservable<IEnumerable<ITreeNode>> GetPathToGoal();

        SearchState StopSearch();
        SearchState Pause();
        SearchState Restart();
    }
}
