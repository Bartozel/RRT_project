using System;

namespace Data.Data
{
    public class TreeNode : Position, ITreeNode
    {
        public double CostToParent { get; set; }
        public ITreeNode Parent { get; set; }

        public TreeNode(IPosition position) : base(position)
        {
        }

        public TreeNode(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }
    }

    public interface ITreeNode : IPosition
    {
        ITreeNode Parent { get; set; }
        double CostToParent { get; set; }
    }
}
