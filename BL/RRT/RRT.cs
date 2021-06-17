using BL.Base;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseRrtSearchEngine
    {
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {

        }

        public override IObservable<Node> CreateNewNodeObs(uint amount, CancellationDisposable cancelationToken)
        {
            EventLoopScheduler scheduler = new EventLoopScheduler();
            //var obs = Observable.Create<Node>(o =>
            //{
            //    var scheduledWork = scheduler.Schedule(() =>
            //    {
            //        try
            //        {
            //            for (int i = 0; i < amount; i++)
            //            {
            //                cancelationToken.Token.ThrowIfCancellationRequested();

            //                var node = GenerateNextStep();
            //                Thread.Sleep(25);
            //                o.OnNext(node);
            //            }
            //            o.OnCompleted();
            //        }
            //        catch (Exception ex)
            //        {
            //            o.OnError(ex);
            //        }

            //    });
            //    return new CompositeDisposable(scheduledWork, cancelationToken);
            //});

            var obs = Observable.Generate(
                0,
                x => x <= amount,
                x => x = x + 1,
                (x) =>
                {
                    cancelationToken.Token.ThrowIfCancellationRequested();
                    var node = GenerateNextStep();
                    this.tree.Insert(node);
                    return node;
                })
                .SubscribeOn(scheduler);

            return obs;
        }

        protected Node GenerateNextStep()
        {
            var position = this.GenerateNewPosition();
            var node = GetNewNode(position);

            return node;
        }

        public override IObservable<Node> UpdateTree()
        {
            return new Node[] { }.ToObservable();
        }

        protected override Node GetNewNode(Position position)
        {
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
