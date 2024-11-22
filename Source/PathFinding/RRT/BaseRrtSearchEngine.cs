using CollisionDetection;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchEngine
{
    abstract class BaseRrtSearchEngine : ISearchEngine_RRT
    {
        protected ISearchedNodesTree _searchAreaTree;
        protected CollisionDetector _collisionManager;
        protected Random rand;
        protected IPosition _root;
        protected IPosition _goal;

        public event EventHandler PathIsAvailable;
        public event EventHandler PathIsBlocked;

        public SearchState SearchState { get; set; }
        public List<ITreeNode> SpanningTree { get; }
        public bool PathExists { get; }

        public int NodesCount => _searchAreaTree.Count;

        public BaseRrtSearchEngine(IPosition root, IPosition goal)
        {
            rand = new Random();
            _searchAreaTree = new SearchTree(GlobalConfig.SearchAreaXValue, GlobalConfig.SearchAreaYValue, root);
            _root = root;
            _goal = goal;
            SearchState = SearchState.Created;
            _collisionManager = new CollisionDetector();
        }
        protected virtual IPosition GenerateNewPosition()
        {
            var n = new SearchTreeNode(rand.Next(GlobalConfig.SearchAreaXValue), rand.Next(GlobalConfig.SearchAreaYValue));
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
            var dist = position.Distance(closestNode);
            if (dist > GlobalConfig.MAX_DISTANCE)
            {
                (int newX, int newY) = CalculateCloserPosition(closestNode, position, dist, GlobalConfig.MAX_DISTANCE);
                var n = new SearchTreeNode(new Position(newX, newY));
                return n;
            }
            else
                return new SearchTreeNode(position);
        }

        private (int newX, int newY) CalculateCloserPosition(ITreeNode closestNode, IPosition position, double dist, int mAX_DISTANCE)
        {
            throw new NotImplementedException();
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
                        double x = position.Distance(node);
                        if (x < shotestDist)
                        {
                            returnPoint = node;
                            shotestDist = x;
                        }
                    }
                    break;
                }
                apend *= 2;
            }

            return returnPoint;
        }

        protected IEnumerable<ITreeNode> FindNodesInCloseArea(IPosition position)
        {
            return _searchAreaTree.GetNodesFromSearchArea(SearchArea.GetNearSearArea(position, GlobalConfig.MAX_DISTANCE));
        }

        protected IEnumerable<ITreeNode> FindNodesInCloseArea(IPosition position, int dist)
        {
            var nearNodes = _searchAreaTree.GetNodesFromSearchArea(SearchArea.GetNearSearArea(position, dist));

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
            child.CostToParent = parent.Distance(child);
        }

        public List<CanvasLine> PathGoalToRoot()
        {
            var newPath = new List<CanvasLine>();
            var nodesNearGoal = FindNodesInCloseArea(_goal);
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
                                    .Select(x => new CanvasLine(x, x.Parent, eColor.Red, 5))
                                    .ToList();
            }

            return newPath;
        }
        public virtual ITreeNode  UpdateTree() => null;

        public abstract ITreeNode GenerateNewNode();
    }
}

