namespace Data.Search
{
    public class SearchTreeNode : Position
    {
        public double CostToParent { get; set; }
        public SearchTreeNode Parent { get; set; }

        public SearchTreeNode(Position position) : base(position)
        {
        }

        public SearchTreeNode(int xCoordinate, int yCoordinate) : base(xCoordinate, yCoordinate)
        {
        }
    }
}
