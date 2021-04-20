using Data.Data;
using Data.Enum;
using BL.Base;
using System;
using BL.Base.Interfaces;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Data;

namespace BL.Agent
{
    public abstract class Agent : AgentBase, IAgent
    {
        public abstract IObservable<Node> StartSearch();
        public abstract void StopSearch();
        public abstract void Pause();
        public abstract void Restart();

        public Agent(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity)
        {
            
        }

    }
}
