using Data.Data;
using Data.Enum;
using System;
using System.Collections.Generic;
using Data.Data.Interfaces;

namespace BL.Agent
{
    public abstract class Agent : AgentBase, IAgent
    {
        public abstract IObservable<ITreeNode> GetNewNodeObs(uint nodeCount);
        public abstract IObservable<ITreeNode> GetUpdateNodeObs();
        public abstract IObservable<IEnumerable<ITreeNode>> GetPathToGoal();

        public abstract SearchState StopSearch();
        public abstract SearchState Pause();
        public abstract SearchState Restart();

        public Agent(IPosition rootCoordinates, IPosition goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity)
        {
            
        }
    }
}
