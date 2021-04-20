using BL.Base;
using BL.Base.Interfaces;
using Data;
using Data.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace DiplomkaBartozel.RRT
{
    class RRT_STAR : RRT
    {
        private IObservable<Node> createObservable;
        public RRT_STAR(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
            SubscribeNewNode();
        }

        private void SubscribeNewNode()
        {
            throw new NotImplementedException();
        }

        public override IObservable<Node> CreateNewNodeObs(int amount)
        {
            return base.CreateNewNodeObs(amount);
        }

        public override IObservable<Node> UpdateTree()
        {
            if (this.NewNodeObs == null)
                throw new Exception("Updatetree:NewNodeObs==null");

            var updateObs = this.NewNodeObs.SelectMany(x => GetChangesFromRewire(x));
            return updateObs;
        }

        protected override Node GetNewNode(Position position)
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
        private IObservable<Node> Rewire(Position newNode)
        {
            var closeNodes = FindNodesInCloseArea(newNode);

            var obs = Observable.Create<Node>(x =>
            {
                foreach (var node in closeNodes)
                {
                    double costOld = PathToRoot(node).cost;

                    var closeNodes2 = FindNodesInCloseArea(node);
                    foreach (var node2 in closeNodes2)
                    {
                        double distance = Misc.Distance(node, node2);
                        if (distance == 0)
                            continue;

                        double cost = PathToRoot(node2).cost + distance;

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

        private Node FindBestParent(Node newNode, IEnumerable<Node> nearNodes)
        {
            Node bNode = null;
            double costMin = double.MaxValue;
            foreach (Node node in nearNodes)
            {
                double distance = Misc.Distance(node, newNode);
                double costNew = PathToRoot(node).cost + distance;
                if (costNew < costMin && collisionManager.IsPathBetweenPointsFree(newNode, node))
                {
                    costMin = costNew;
                    bNode = node;
                }
            }
            return bNode;
        }

        public IObservable<Node> GetChangesFromRewire(Position position)
        {
            var changedNodes = Rewire(position);
            return changedNodes;
        }
    }
}
