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

namespace BL.Agent
{
    public class Agent_RRT : Agent
    {
        private ISearchEngine_RRT searchEngine;
        CancellationDisposable cancellationToken;

        /// <summary>
        /// Default value 5000
        /// </summary>
        public uint NodeQuantity { get; set; }

        public override IObservable<Node> GetNewNodeObs
        {
            get
            {
                if (this.newNodeObs == null)
                    this.newNodeObs = NewNodeObservable();

                return this.newNodeObs;
            }
        }
        private IObservable<Node> newNodeObs;

        public override IObservable<Node> GetUpdateNodeObs
        {
            get
            {
                if (this.updateNodeObs == null)
                {
                    this.updateNodeObs = GetUpdateObservable();
                }

                return this.updateNodeObs;
            }
        }
        private IObservable<Node> updateNodeObs;

        public Agent_RRT(Position rootCoordinates, Position goalCoordinates, int velocity, SearchType sp) : base(rootCoordinates, goalCoordinates, velocity, sp)
        {
            this.searchEngine = SearchFactory.CreateRrtEngine(sp, rootCoordinates, goalCoordinates);
            this.cancellationToken = new CancellationDisposable();
            NodeQuantity = 5000;
        }

        public override void StopSearch()
        {
            cancellationToken.Dispose();
        }

        public override void Pause()
        {
            throw new NotImplementedException();
        }

        public override void Restart()
        {
            throw new NotImplementedException();
        }

        private IObservable<Node> NewNodeObservable()
        {
            var obs = searchEngine.CreateNewNodeObs(this.NodeQuantity, cancellationToken);
            return obs;
        }

        private IObservable<Node> GetUpdateObservable()
        {
            if (this.newNodeObs == null)
                this.newNodeObs = NewNodeObservable();

            var obs= searchEngine.UpdateTree();
            return obs;
        }
    }
}
