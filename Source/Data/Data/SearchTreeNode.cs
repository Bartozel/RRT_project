namespace Data
{
    public class SearchTreeNode : Position, ITreeNode
    {
        public double CostToParent { get; set; }
        public ITreeNode Parent { get; set; }

        public SearchTreeNode(IPosition position) : base(position)
        {
        }

        public SearchTreeNode(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }
    }

    public interface ITreeNode : IPosition
    {
        ITreeNode Parent { get; set; }
        double CostToParent { get; set; }
    }
}
