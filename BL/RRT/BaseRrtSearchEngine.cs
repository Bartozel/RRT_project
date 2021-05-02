using BL.Base;
using BL.Base.Interfaces;
using Data;
using Data.Data;
using Data.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Disposables;
using System.Threading;

namespace DiplomkaBartozel.RRT
{
    abstract class BaseRrtSearchEngine :  ISearchEngine_RRT
    {
        protected ITreeDataStructure tree;
        protected CollisionManager collisionManager;
        protected Random rand;
        protected Position root;
        protected Position goal;

        public event EventHandler PathIsAvailable;
        public event EventHandler PathIsBlocked;

        public SearchState SearchState { get; set; }
        public List<Node> SpanningTree { get; }
        public bool PathExist { get; }

        public uint NodesCount => this.tree.Count;

        public BaseRrtSearchEngine(Position root, Position goal)
        {
            rand = new Random();
            tree = new Tree(root);
            this.root = root;
            this.goal = goal;
            SearchState = SearchState.Creatred;
            collisionManager = new CollisionManager();
        }
        protected virtual Position GenerateNewPosition()
        {
            var n = new Position(rand.Next(GlobalConfig.WidthOfSearchWindow), rand.Next(GlobalConfig.HeighOfSearchWindow));
            return n;
        }
        /// <summary>
        /// Calculate new position of newNode if new node is too far from closest node.
        /// </summary>
        /// <param name="node">nove</param>
        /// <param name="closestNode"></param>
        /// <returns></returns>
        protected Node Steer(Position position, Node closestNode)
        {
            var dist = Misc.Distance(closestNode, position);
            if (dist > GlobalConfig.MAX_DISTANCE)
            {
                (int newX, int newY) = Misc.CalculateCloserPosition(closestNode, position, dist, GlobalConfig.MAX_DISTANCE);
                var n = new Node(new Position(newX, newY));
                return n;
            }
            else
                return new Node(position);
        }
        protected Node FindClosestNode(Position position)
        {
            int apend = GlobalConfig.MAX_DISTANCE;
            Node returnPoint = null;

            while (true)
            {
                var list = FindNodesInCloseArea(position, apend);
                if (list.Any())
                {
                    double shotestDist = double.MaxValue;
                    foreach (Node node in list)
                    {
                        var x = Misc.Distance(position, node);
                        if (x < shotestDist)
                        {
                            returnPoint = node;
                            shotestDist = x;
                        }
                    }
                    break;
                }
                else
                    apend *= 2;
            }

            return returnPoint;
        }

        protected IEnumerable<Node> FindNodesInCloseArea(Position position, int dist = GlobalConfig.MAX_DISTANCE)
        {
            var nearNodes = tree.Search(SearchArea.GetNearSearArea(position, dist));

            return nearNodes;
        }
        public static (double cost, List<Node> nodes) PathToRoot(Node node)
        {
            Node searchNode = node;
            double costOfPath = 0;
            List<Node> nodes = null;
            while (searchNode.Parent != null)
            {
                costOfPath += searchNode.CostToParent;
                searchNode = searchNode.Parent;
            }
            return (costOfPath, nodes);
        }
        protected void AddParent(Node parent, Node child)
        {
            child.Parent = parent;
            child.CostToParent = Misc.Distance(parent, child);
        }
        public List<TreeLine> PathGoalToRoot()
        {
            var newPath = new List<TreeLine>();
            var nodesNearGoal = FindNodesInCloseArea(this.goal);
            if (nodesNearGoal.Any())
            {
                List<Node> bestNodes = null;
                double bestCost = double.MaxValue;
                foreach (var n in nodesNearGoal)
                {
                    var path = PathToRoot(n);
                    if (bestCost < path.cost)
                    {
                        bestCost = path.cost;
                        bestNodes = path.nodes;
                    }
                }

                newPath = bestNodes.Where(x => x.Parent != null)
                                    .Select(x => new TreeLine(x, x.Parent, Color.Red, 5))
                                    .ToList();
            }

            return newPath;
        }

        protected abstract Node GetNewNode(Position node);
        public abstract IObservable<Node> UpdateTree();
        public abstract IObservable<Node> CreateNewNodeObs(uint amount, CancellationDisposable cancellationToken);
    }
}

