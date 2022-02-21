using Data.Data;
using Data.Enum;
using BL.Base;
using System;
using BL.Base.Interfaces;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Data;
using System.Collections.Generic;

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
