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

        public override IObservable<ITreeNode> GetNewNodeObs(uint nodesCount)
        {
            if (this.newNodeObs == null)
                this.newNodeObs = NewNodeObservable(nodesCount);

            return this.newNodeObs;
        }
        private IObservable<ITreeNode> newNodeObs;

        public override IObservable<ITreeNode> GetUpdateNodeObs()
        {
            if (this.updateNodeObs == null)
                this.updateNodeObs = GetUpdateObservable();

            return this.updateNodeObs;
        }

        private IObservable<ITreeNode> updateNodeObs;

        public Agent_RRT(IPosition rootCoordinates, IPosition goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity, sp)
        {
            this.searchEngine = SearchFactory.CreateRrtEngine(sp, rootCoordinates, goalCoordinates);
            this.cancellationToken = new CancellationTokenSource();
        }

        public override SearchState StopSearch()
        {
            cancellationToken.Cancel();
            return SearchState.Stopped;
        }

        public override SearchState Pause()
        {
            throw new NotImplementedException();
        }

        public override SearchState Restart()
        {
            throw new NotImplementedException();
        }

        private IObservable<ITreeNode> NewNodeObservable(uint nodesCount)
        {
            var cd = new CancellationDisposable(cancellationToken);
            var obs = searchEngine.CreateNewNodeObs(nodesCount, cd);
            return obs;
        }

        private IObservable<ITreeNode> GetUpdateObservable()
        {
            if (this.newNodeObs == null)
                throw new Exception("Update before start 'create new'");

            var obs = searchEngine.UpdateTree();
            return obs;
        }

        public override IObservable<IEnumerable<ITreeNode>> GetPathToGoal()
        {
            throw new NotImplementedException();
        }
    }
}
