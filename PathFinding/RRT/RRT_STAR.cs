using Data;
using System;
using System.Collections.Generic;

namespace SearchEngine
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

        public override ITreeNode UpdateTree()
        {
            return null;
        }

        protected ITreeNode GetNewNode(IPosition position)
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
        private void Rewire(IPosition newNode)
        {
            var closeNodes = FindNodesInCloseArea(newNode);

            foreach (var node in closeNodes)
            {
                double costOld = PathToRoot(node).pathCost;

                var closeNodes2 = FindNodesInCloseArea(node);
                foreach (var node2 in closeNodes2)
                {
                    double distance = node.Distance( node2);
                    if (distance == 0)
                        continue;

                    double cost = PathToRoot(node2).pathCost + distance;

                    if (cost < costOld && _collisionManager.IsPathBetweenPointsFree(node, node2))
                    {
                        node.Parent = node2;
                        node.CostToParent = distance;
                        costOld = cost;
                    }
                }
            }

        }

        private ITreeNode FindBestParent(ITreeNode newNode, IEnumerable<ITreeNode> nearNodes)
        {
            ITreeNode bNode = null;
            double costMin = double.MaxValue;
            foreach (ITreeNode node in nearNodes)
            {
                double distance = node.Distance( newNode);
                double costNew = PathToRoot(node).pathCost + distance;
                if (costNew < costMin && _collisionManager.IsPathBetweenPointsFree(newNode, node))
                {
                    costMin = costNew;
                    bNode = node;
                }
            }
            return bNode;
        }

    }
}
