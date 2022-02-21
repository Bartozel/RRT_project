using BL.Base;
using Data;
using Data.Data;
using Data.Data.Interfaces;
using Data.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reactive.Disposables;

namespace DiplomkaBartozel.RRT
{
    abstract class BaseRrtSearchEngine : ISearchEngine_RRT
    {
        protected ITree tree;
        protected CollisionManager collisionManager;
        protected Random rand;
        protected IPosition root;
        protected IPosition goal;

        public event EventHandler PathIsAvailable;
        public event EventHandler PathIsBlocked;

        public SearchState SearchState { get; set; }
        public List<ITreeNode> SpanningTree { get; }
        public bool PathExists { get; }

        public int NodesCount => this.tree.Count;

        public BaseRrtSearchEngine(IPosition root, IPosition goal)
        {
            rand = new Random();
            tree = new Tree(GlobalConfig.WidthOfSearchWindow, GlobalConfig.HeighOfSearchWindow, root);
            this.root = root;
            this.goal = goal;
            SearchState = SearchState.Creatred;
            collisionManager = new CollisionManager();
        }
        protected virtual IPosition GenerateNewPosition()
        {
            var n = new TreeNode(rand.Next(GlobalConfig.WidthOfSearchWindow), rand.Next(GlobalConfig.HeighOfSearchWindow));
            return n;
        }
        /// <summary>
        /// Calculate new position of newNode if new node is too far from closest node.
        /// </summary>
        /// <param name="node">nove</param>
        /// <param name="closestNode"></param>
        /// <returns></returns>
        protected ITreeNode Steer(IPosition position, ITreeNode closestNode)
        {
            var dist = Misc.Distance(closestNode, position);
            if (dist > GlobalConfig.MAX_DISTANCE)
            {
                (int newX, int newY) = Misc.CalculateCloserPosition(closestNode, position, dist, GlobalConfig.MAX_DISTANCE);
                var n = new TreeNode(new Position(newX, newY));
                return n;
            }
            else
                return new TreeNode(position);
        }
        protected ITreeNode FindClosestNode(IPosition position)
        {
            int apend = GlobalConfig.MAX_DISTANCE;
            ITreeNode returnPoint = null;

            while (true)
            {
                var list = FindNodesInCloseArea(position, apend);
                if (list.Any())
                {
                    double shotestDist = double.MaxValue;
                    foreach (ITreeNode node in list)
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

        protected IEnumerable<ITreeNode> FindNodesInCloseArea(IPosition position, int dist = GlobalConfig.MAX_DISTANCE)
        {
            var nearNodes = tree.Search(SearchArea.GetNearSearArea(position, dist));

            return nearNodes;
        }

        public static (double pathCost, IEnumerable<ITreeNode> path) PathToRoot(ITreeNode node)
        {
            ITreeNode searchNode = node;
            double costOfPath = 0;
            IEnumerable<ITreeNode> nodes = new List<ITreeNode>();
            while (searchNode.Parent != null)
            {
                costOfPath += searchNode.CostToParent;
                searchNode = searchNode.Parent;
            }
            return (costOfPath, nodes);
        }
        protected void AddParent(ITreeNode parent, ITreeNode child)
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
                IEnumerable<ITreeNode> bestNodes = null;
                double bestCost = double.MaxValue;
                foreach (var n in nodesNearGoal)
                {
                    var path = PathToRoot(n);
                    if (bestCost < path.pathCost)
                    {
                        bestCost = path.pathCost;
                        bestNodes = path.path;
                    }
                }

                newPath = bestNodes.Where(x => x.Parent != null)
                                    .Select(x => new TreeLine(x, x.Parent, Color.Red, 5))
                                    .ToList();
            }

            return newPath;
        }

        protected abstract ITreeNode GetNewNode(IPosition node);
        public abstract IObservable<ITreeNode> UpdateTree();
        public abstract IObservable<ITreeNode> CreateNewNodeObs(uint amount, CancellationDisposable cancellationToken);
    }
}

