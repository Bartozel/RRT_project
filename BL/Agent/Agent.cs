using DiplomkaBartozel.Interfaces;
using Data.Data;
using Data.Enum;
using BL.Base;
using System;
using System.Reactive.Linq;

namespace BL.Agent
{
    public class Agent : AgentBase, IAgent
    {
        private ISearchEngine searchEngine;

        public override void Move()
        {
            //will be implemented with alg for dynamic planning RRTx
        }

        public IDisposable SubscribeSearch(IObserver<TreeLine> observer)
        {
            throw new NotImplementedException();
        }

        public void StopSearch()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Restart()
        {
            throw new NotImplementedException();
        }

        public Agent(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity)
        {
            this.searchEngine = SearchFactory.Create(sp, rootCoordinates, goalCoordinates);
        }

    }
}
