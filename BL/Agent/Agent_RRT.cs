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
    public class Agent_RRT : Agent
    {
        private ISearchEngine_RRT searchEngine;
        private List<IObserver_RRT> observer;

        public Agent_RRT(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity, sp)
        {
            this.searchEngine = SearchFactory.CreateRrtEngine(sp, rootCoordinates, goalCoordinates);
            this.observer = new List<IObserver_RRT>();
        }

        public void SubscribeSearch(IObserver_RRT observer)
        {
            this.observer.Add(observer);
        }

        public override void StopSearch()
        {
            throw new NotImplementedException();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Restart()
        {
            throw new NotImplementedException();
        }
    }
}
