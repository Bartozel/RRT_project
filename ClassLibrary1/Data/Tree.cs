using System;
using Data.Data;
using System.Collections.Generic;
using System.Linq;
using Data.Data.Interfaces;

namespace Data.Data
{
    public class Tree : ITree
    {
        private ITreeNode[,] _tree;
        public int Count => _tree.Length;
        public ITreeNode Root { get; private set; }

        public Tree(int xRange, int yRange, IPosition rootPosition)
        {
            _tree = new ITreeNode[xRange, yRange];
            Root = new TreeNode(rootPosition);
            Insert(Root);
        }

        public bool Insert(ITreeNode point)
        {
            var node = _tree[point.XCoordinate, point.YCoordinate];
            var returnVal = node == null;
            if (returnVal)
                _tree[point.XCoordinate, point.YCoordinate] = point;

            return returnVal;
        }

        public bool BulkInsert(ITreeNode[] nodes)
        {
            if (nodes != null)
            {
                for (int i = 0; i < nodes.Count(); i++)
                    Insert(nodes[i]);

                return true;
            }
            return false;
        }

        public void Clear(ITreeNode node)
        {
            _tree[node.XCoordinate, node.YCoordinate] = null;
        }

        public void ClearAll()
        {
            _tree = new TreeNode[_tree.GetLength(0), _tree.GetLength(1)];
        }

        public IEnumerable<ITreeNode> GetNodesFromSearchArea(SearchArea area)
        {
            if (area == null)
                throw new Exception("Tree->Search area=null");

            var nodes = new List<ITreeNode>();
            for (int x = area.MinX; x < area.MaxX; x++)
            {
                for (int y = area.MinY; y < area.MaxY; y++)
                {
                    var node = _tree[x, y];
                    if (node != null)
                        nodes.Add(node);
                }
            }
            return nodes;
        }
    }

}
