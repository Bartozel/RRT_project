using System;
using Data.Data;
using System.Collections.Generic;
using Data.Data.Interfaces;

namespace Data.Data
{
    public class Tree : ITree
    {
        private ITreeNode[,] _tree;
        public int Count => _tree.Length;
        public ITreeNode Root { get; private set; }
        private int _rows;
        private int _columns;

        public Tree(int rows, int columns, IPosition rootPosition)
        {
            _rows = rows;
            _columns = columns;
            _tree = new ITreeNode[columns, rows];
            Root = new TreeNode(rootPosition);
            Insert(Root);
        }

        public bool Insert(ITreeNode point)
        {
            var node = _tree[point.XCoordinate, point.YCoordinate];
            var returnVal = node != null;
            if (returnVal)
                _tree[point.XCoordinate, point.YCoordinate] = point;

            return returnVal;
        }

        public bool BulkInsert(IEnumerable<ITreeNode> nodes)
        {
            return true;
        }

        public void Clear(ITreeNode node)
        {
            _tree[node.XCoordinate, node.YCoordinate] = null;
        }

        public void ClearAll()
        {
            _tree = new TreeNode[_columns, _rows];
        }

        public IEnumerable<ITreeNode> Search(SearchArea area)
        {
            if (area == null)
                throw new Exception("Tree->Search area=null");

            var nodes = new List<ITreeNode>();
            for (int x = area.MinX; x <= area.MaxX; x++)
            {
                for (int y = area.MinY; y <= area.MaxY; y++)
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
