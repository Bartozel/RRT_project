using DiplomkaBartozel.Base;
using DiplomkaBartozel.Base.Data;
using DiplomkaBartozel.Base.Enum;
using DiplomkaBartozel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DiplomkaBartozel.RRT
{
    abstract class BaseSearchEngine : ISearchEngine, ISearchEngine_RRT
    {
        protected ITreeDataStructure tree;
        protected CollisionManager collisionManager;
        protected Random rand;
        protected Position root;
        protected Position goal;
        private List<IObservable<>> observables;

        public event EventHandler PathIsAvailable;
        public event EventHandler PathIsBlocked;

        public SearchState SearchState { get; set; }
        public List<Node> SpanningTree => throw new NotImplementedException();

        List<Node> ISearchEngine_RRT.SpanningTree => throw new NotImplementedException();

        public bool PathExist => throw new NotImplementedException();

        public BaseSearchEngine(Position root, Position goal)
        {
            rand = new Random();
            tree = new Tree(root);
            this.root = root;
            this.goal = goal;
            SearchState = SearchState.Creatred;
            collisionManager = new CollisionManager();
        }

        protected virtual Node GenerateNewNode()
        {
            var n = new Node(rand.Next(GlobalConfig.WidthOfSearchArea), rand.Next(GlobalConfig.HeighOfSearchArea));
            return n;
        }

        /// <summary>
        /// Calculate new position of newNode if new node is too far from closest node.
        /// </summary>
        /// <param name="newNode">nove</param>
        /// <param name="closestNode"></param>
        /// <returns></returns>
        protected Node Steer(Node newNode, Node closestNode)
        {
            var dist = Distance(closestNode, newNode);
            if (dist > GlobalConfig.maxDist)
            {
                double shift = GlobalConfig.maxDist / dist;
                var newXCoordinate = (1 - shift) * closestNode.MaxX + shift * newNode.MaxX;
                var newYCoordinate = (1 - shift) * closestNode.MaxY + shift * newNode.MaxY;
                var n = new Node(newXCoordinate.AsInt(), newYCoordinate.AsInt());

                return n;
            }
            else
                return newNode;
        }

        protected Node FindClosestNode(Position position)
        {
            int apend = GlobalConfig.maxDist;
            Node returnPoint = null;

            while (true)
            {
                var list = FindNodesInCloseArea(position);
                if (list.Any())
                {
                    double shotestDist = double.MaxValue;
                    foreach (Node node in list)
                    {
                        var x = Distance(position, node);
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
            var nearNodes = tree.Search(SearchArea.GetNodeNearArea(position));

            return nearNodes;
        }

        public static double CostToRoot(Node node)
        {
            Node searchNode = node;
            double costOfPath = 0;
            while (searchNode.Parent != null)
            {
                costOfPath += searchNode.CostToParent;
                searchNode = searchNode.Parent;
            }
            return costOfPath;
        }

        public static double Distance(Position node1, Position node2)
        {
            return Math.Sqrt(Math.Pow(node1.XCoordinate - node2.XCoordinate, 2) + Math.Pow(node1.YCoordinate - node2.YCoordinate, 2));
        }

        protected abstract Node Process(Node node);

        protected void AddParent(Node parent, Node child)
        {
            child.Parent = parent;
            child.CostToParent = Distance(parent, child);
        }

        protected int CalculateNumberOfSamples()
        {
            throw new NotImplementedException();
        }

        public void StartSearch()
        {
            var n = GenerateNewNode();
            n = Process(n);

        }

        public void StopSearch()
        {
            throw new NotImplementedException();
        }

        public void RestartSearch()
        {
            throw new NotImplementedException();
        }

        public List<Node> PathToGoal()
        {
            throw new NotImplementedException();
        }

        public void ChangeRoot()
        {
            throw new NotImplementedException();
        }
    }
}

