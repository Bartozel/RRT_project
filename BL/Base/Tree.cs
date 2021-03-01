using Data.Data;
using DiplomkaBartozel.Interfaces;
using RBush;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DiplomkaBartozel.Base
{
    class Tree : ITreeDataStructure
    {
        private readonly RBush<Node> tree;
        public int NodeSum => throw new NotImplementedException();

        private Tree()
        {
            this.tree = new RBush<Node>(GlobalConfig.MaxEntries);
        }

        public Tree(Position position) : this()
        {
            var root = new Node(position);
            tree.Insert(root);
        }

        public void Insert(Node point)
        {
            tree.Insert(point);
        }

        public void BulkInsert(IEnumerable<Node> nodes)
        {
            
        }

        public void Clear(Node node)
        {
            
        }

        public void ClearAll()
        {
           
        }

        public IEnumerable<Node> GetAllNodes()
        {
           
        }

        public IEnumerable<Node> Search(SearchArea area)
        {
           
        }
    }

}
