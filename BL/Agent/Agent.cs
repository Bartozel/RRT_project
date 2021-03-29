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
    public class Agent : AgentBase, IAgent
    {
        private ISearchEngine searchEngine;
        private IObserver_RRT observer;

        public override void Move()
        {
            //will be implemented with alg for dynamic planning RRTx
        }

        public void SubscribeSearch(IObserver_RRT observer)
        {
            this.observer = observer;
        }

        private void SubscribeUpdate()
        {
            
        }

        private void SubscribeAdd()
        {
            var numOfSamples = 2000;//GlobalConfig.
            var observeble = Observable.Create<TreeLine>(x =>
            {
                int i = 0;
                while(i >=numOfSamples)
                {
                    x.OnNext(searchEngine.GenerateNextStep());
                }
                x.OnCompleted();
                return Disposable.Empty;
            });

            observeble.Subscribe(this.observer);
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
