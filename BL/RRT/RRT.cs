using BL.Base;
using BL.Base.Interfaces;
using Data;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Navigation;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseRrtSearchEngine
    {
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {

        }

        public override IObservable<Node> CreateNewNodeObs(int amount)
        {
            IScheduler scheduler = DefaultScheduler.Instance;
            var obs =  Observable.Create<Node>(o =>
            {
                var cancellation = new CancellationDisposable();
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
                return new CompositeDisposable(scheduledWork, cancellation);
            });

            this.NewNodeObs = obs;
            return this.NewNodeObs;
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
