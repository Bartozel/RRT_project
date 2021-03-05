using BL.Base;
using Data;
using Data.Data;
using Data.Enum;
using DiplomkaBartozel.Base;
using DiplomkaBartozel.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Shapes;

namespace DiplomkaBartozel.RRT
{
    abstract class BaseSearchEngine : ISearchEngine, ISearchEngine_RRT
    {
        protected ITreeDataStructure tree;
        protected CollisionManager collisionManager;
        protected Random rand;
        protected Position root;
        protected Position goal;
        private CancellationTokenSource token;

        public event EventHandler PathIsAvailable;
        public event EventHandler PathIsBlocked;

        public SearchState SearchState { get; set; }
        public List<Node> SpanningTree { get; }

        List<Node> ISearchEngine_RRT.SpanningTree { get; }

        public bool PathExist { get; }

        public BaseSearchEngine(Position root, Position goal)
        {
            rand = new Random();
            tree = new Tree(root);
            this.root = root;
            this.goal = goal;
            SearchState = SearchState.Creatred;
            collisionManager = new CollisionManager();
            token = new CancellationTokenSource();
        }

        protected virtual Node GenerateNewNode()
        {
            var n = new Node(rand.Next(GlobalConfig.WidthOfSearchWindow), rand.Next(GlobalConfig.HeighOfSearchWindow));
            return n;
        }

        /// <summary>
        /// Calculate new position of newNode if new node is too far from closest node.
        /// </summary>
        /// <param name="node">nove</param>
        /// <param name="closestNode"></param>
        /// <returns></returns>
        protected Node Steer(Node node, Node closestNode)
        {
            var dist = Misc.Distance(closestNode, node);
            if (dist > GlobalConfig.MaxDist)
            {
                (int newX, int newY) = Misc.CalculateCloserPosition(closestNode, node, dist, GlobalConfig.MaxDist);
                var n = new Node(newX, newY);
                return n;
            }
            else
                return node;
        }

        protected Node FindClosestNode(Position position)
        {
            int apend = GlobalConfig.MaxDist;
            Node returnPoint = null;

            while (true)
            {
                var list = FindNodesInCloseArea(position);
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

        protected IEnumerable<Node> FindNodesInCloseArea(Position position)
        {
            var nearNodes = tree.Search(SearchArea.GetNearSearArea(position));

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

        protected abstract Node Process(Node node);

        protected void AddParent(Node parent, Node child)
        {
            child.Parent = parent;
            child.CostToParent = Misc.Distance(parent, child);
        }

        public void StartSearch()
        {
            Start();

        }

        private void Start()
        {
            while (!this.token.IsCancellationRequested)
            {
                var n = GenerateNewNode();
                n = Process(n);
                var line = new TreeLine(n, n.Parent);
                //observer.OnNext(line);
            }
        }

        public void StopSearch()
        {
            this.SearchState = SearchState.Stopped;
            this.token.Cancel();
        }

        public void RestartSearch()
        {
            this.SearchState = SearchState.Creatred;
            this.tree.ClearAll();
            this.token.Cancel();
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

        public void ChangeRoot()
        {
            //TODO
        }
    }
}

