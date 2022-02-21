using BL.Base;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace DiplomkaBartozel.RRT
{
    class RRT_STAR : RRT
    {
        public IObservable<ITreeNode> NewNodeObs { get; protected set; }

        public RRT_STAR(IPosition startPos, IPosition goalPos) : base(startPos, goalPos)
        {
            SubscribeNewNode();
        }

        private void SubscribeNewNode()
        {
            throw new NotImplementedException();
        }

        public override IObservable<ITreeNode> CreateNewNodeObs(uint amount, CancellationDisposable cancelationToken)
        {
            this.NewNodeObs = base.CreateNewNodeObs(amount, cancelationToken);
            return this.NewNodeObs;
        }

        public override IObservable<ITreeNode> UpdateTree()
        {
            if (this.NewNodeObs == null)
                throw new Exception("Updatetree:NewNodeObs==null");

            var updateObs = this.NewNodeObs.SelectMany(x => GetChangesFromRewire(x));
            return updateObs;
        }

        protected override ITreeNode GetNewNode(IPosition position)
        {
            var node = base.GetNewNode(position);

            var closeNodes = FindNodesInCloseArea(node);
            var newParent = FindBestParent(node, closeNodes);
            AddParent(newParent, node);

            return node;
        }

        /// <summary>
        /// Rewire surroundings of newly added node, to keep tree near to optimal.
        /// </summary>
        /// <param name="xNew"></param>
        private IObservable<ITreeNode> Rewire(IPosition newNode)
        {
            var closeNodes = FindNodesInCloseArea(newNode);

            var obs = Observable.Create<ITreeNode>(x =>
            {
                foreach (var node in closeNodes)
                {
                    double costOld = PathToRoot(node).pathCost;

                    var closeNodes2 = FindNodesInCloseArea(node);
                    foreach (var node2 in closeNodes2)
                    {
                        double distance = Misc.Distance(node, node2);
                        if (distance == 0)
                            continue;

                        double cost = PathToRoot(node2).pathCost + distance;

                        if (cost < costOld && collisionManager.IsPathBetweenPointsFree(node, node2))
                        {
                            node.Parent = node2;
                            node.CostToParent = distance;
                            costOld = cost;
                            x.OnNext(node);
                        }
                    }
                }
                return Disposable.Empty;
            });

            return obs;
        }

        private ITreeNode FindBestParent(ITreeNode newNode, IEnumerable<ITreeNode> nearNodes)
        {
            ITreeNode bNode = null;
            double costMin = double.MaxValue;
            foreach (ITreeNode node in nearNodes)
            {
                double distance = Misc.Distance(node, newNode);
                double costNew = PathToRoot(node).pathCost + distance;
                if (costNew < costMin && collisionManager.IsPathBetweenPointsFree(newNode, node))
                {
                    costMin = costNew;
                    bNode = node;
                }
            }
            return bNode;
        }

        public IObservable<ITreeNode> GetChangesFromRewire(IPosition position)
        {
            var changedNodes = Rewire(position);
            return changedNodes;
        }
    }
}
