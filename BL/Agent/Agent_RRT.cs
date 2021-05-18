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
using System.Reactive.Concurrency;
using System.Threading;
using System.Threading.Tasks;
using System.Reactive.Threading.Tasks;

namespace BL.Agent
{
    public class Agent_RRT : Agent
    {
        private ISearchEngine_RRT searchEngine;
        CancellationTokenSource cancellationToken;


        public override IObservable<Node> GetNewNodeObs(uint nodesCount)
        {
            if (this.newNodeObs == null)
                this.newNodeObs = NewNodeObservable(nodesCount);

            return this.newNodeObs;
        }
        private IObservable<Node> newNodeObs;

        public override IObservable<Node> GetUpdateNodeObs()
        {
            if (this.updateNodeObs == null)
                this.updateNodeObs = GetUpdateObservable();

            return this.updateNodeObs;
        }

        private IObservable<Node> updateNodeObs;

        public Agent_RRT(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity, sp)
        {
            this.searchEngine = SearchFactory.CreateRrtEngine(sp, rootCoordinates, goalCoordinates);
            this.cancellationToken = new CancellationTokenSource();
        }

        public override void StopSearch()
        {
            cancellationToken.Cancel();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Restart()
        {
            throw new NotImplementedException();
        }

        private IObservable<Node> NewNodeObservable(uint nodesCount)
        {
            var cd = new CancellationDisposable(cancellationToken);
            var obs = searchEngine.CreateNewNodeObs(nodesCount, cd);
            return obs;
        }

        private IObservable<Node> GetUpdateObservable()
        {
            if (this.newNodeObs == null)
                throw new Exception("Update before start 'create new'");

            var obs = searchEngine.UpdateTree();
            return obs;
        }
    }
}
