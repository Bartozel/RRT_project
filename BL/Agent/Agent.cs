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
        public abstract IObservable<Node> GetNewNodeObs(uint nodeCount);
        public abstract IObservable<Node> GetUpdateNodeObs();
        public abstract IObservable<List<Node>> GetPathToGoal();

        public abstract SearchState StopSearch();
        public abstract SearchState Pause();
        public abstract SearchState Restart();

        public Agent(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity)
        {
            
        }
    }
}
