using BL.Base.Interfaces;
using Data;
using Data.Data;
using RBush;
using System;
using System.Collections.Generic;

namespace BL.Base
{
    class Tree : ITreeDataStructure
    {
        private readonly RBush<Node> tree;
        object _lock;
        public int Count
        {
            get
            {
                return this.tree.Count;
            }
        }

        private Tree()
        {
            _lock = new object();
            this.tree = new RBush<Node>(GlobalConfig.MaxEntries);
        }

        public Tree(Position position) : this()
        {
            var root = new Node(position);
            tree.Insert(root);
        }

        public void Insert(Node point)
        {
            //lock (_lock)
            tree.Insert(point);
        }

        public void BulkInsert(IEnumerable<Node> nodes)
        {

        }

        public void Clear(Node node)
        {
            this.tree.Delete(node);
        }

        public void ClearAll()
        {
            this.tree.Clear();
        }

        public IEnumerable<Node> GetAllNodes()
        {
            return this.tree.Search();
        }

        public IEnumerable<Node> Search(SearchArea area)
        {
            //lock (_lock)
            return this.tree.Search(area.ToEnvelope());
        }
    }

}
