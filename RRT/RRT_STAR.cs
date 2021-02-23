using DiplomkaBartozel.Base;
using DiplomkaBartozel.Base.Data;
using DiplomkaBartozel.RRT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.RRT
{
    class RRT_STAR : RRT
    {
        public RRT_STAR(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
        }

        protected override Node Process(Node node)
        {
            node = base.Process(node);

            var closeNodes = FindNodesInCloseArea(node);
            var newParent = FindBestParent(node, closeNodes);
            AddParent(newParent, node);

            var cnWithouRoot = closeNodes.Where(x => !x.Equals(this.root)); //can't make better position for root
            RewireTree(cnWithouRoot);

            return node;
        }

        /// <summary>
        /// Rewire surroundings of newly added node, to keep tree near to optimal.
        /// </summary>
        /// <param name="xNew"></param>
        private void RewireTree(IEnumerable<Node> closeNodes)
        {
            foreach (var node in closeNodes)
            {
                double costOld = CostToRoot(node);

                var closeNodes2 = FindNodesInCloseArea(node);
                foreach (var node2 in closeNodes2)
                {
                    double distance = Distance(node, node2);
                    if (distance == 0)
                        continue;

                    double cost = CostToRoot(node2) + distance;

                    if (cost < costOld && collisionManager.IsPathBetweenPointsFree(node, node2))
                    {
                        node.Parent = node2;
                        node.CostToParent = distance;
                        costOld = cost;
                    }
                }
            }
        }

        private Node FindBestParent(Node newNode, IEnumerable<Node> nearNodes)
        {
            Node bNode = null;
            double costMin = double.MaxValue;
            foreach (Node node in nearNodes)
            {
                double distance = Distance(node, newNode);
                double costNew = CostToRoot(node) + distance;
                if (costNew < costMin && collisionManager.IsPathBetweenPointsFree(newNode, node))
                {
                    costMin = costNew;
                    bNode = node;
                }
            }
            return bNode;
        }
    }
}
