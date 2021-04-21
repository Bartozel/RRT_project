using BL.Base;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseRrtSearchEngine
    {
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {

        }

        public override IObservable<Node> CreateNewNodeObs(uint amount, CancellationDisposable cancelationToken)
        {
            IScheduler scheduler = DefaultScheduler.Instance;
            var obs =  Observable.Create<Node>(o =>
            {
                var scheduledWork = scheduler.Schedule(() =>
                {
                    try
                    {
                        for (int x = 0; x <= amount; x++)
                        {
                            var node = GenerateNextStep();
                            o.OnNext(node);
                        }
                        o.OnCompleted();
                    }
                    catch (Exception ex)
                    {
                        o.OnError(ex);
                    }
                });
                return new CompositeDisposable(scheduledWork, cancelationToken);
            });

            return obs;
        }

        protected Node GenerateNextStep()
        {
            var position = this.GenerateNewPosition();
            var node = GetNewNode(position);
            this.tree.Insert(node);
            return node;
        }

        public override IObservable<Node> UpdateTree()
        {
            return new List<Node>().ToObservable();
        }

        protected override Node GetNewNode(Position position)
        {
            //Node randNode = GenerateNewNode();
            Node closestNode = FindClosestNode(position);
            Node newNode = Steer(position, closestNode);
            if (collisionManager.IsPathBetweenPointsFree(newNode, closestNode))
            {
                newNode.Parent = closestNode;
                newNode.CostToParent = Misc.Distance(newNode, closestNode);
            }

            return newNode;
        }
    }
}
