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
        public RRT(IPosition startPos, IPosition goalPos) : base(startPos, goalPos)
        {

        }

        public override IObservable<ITreeNode> CreateNewNodeObs(uint amount, CancellationDisposable cancelationToken)
        {
            EventLoopScheduler scheduler = new EventLoopScheduler();
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

        protected ITreeNode GenerateNextStep()
        {
            var position = this.GenerateNewPosition();
            var node = GetNewNode(position);

            return node;
        }

        public override IObservable<ITreeNode> UpdateTree()
        {
            return new TreeNode[] { }.ToObservable();
        }

        protected override ITreeNode GetNewNode(IPosition position)
        {
            ITreeNode closestNode = FindClosestNode(position);
            ITreeNode newNode = Steer(position, closestNode);
            if (collisionManager.IsPathBetweenPointsFree(newNode, closestNode))
            {
                newNode.Parent = closestNode;
                newNode.CostToParent = Misc.Distance(newNode, closestNode);
            }

            return newNode;
        }
    }
}
