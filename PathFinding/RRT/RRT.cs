using Data;

namespace SearchEngine
{
    class RRT : BaseRrtSearchEngine
    {
        public RRT(IPosition startPos, IPosition goalPos) : base(startPos, goalPos)
        {

        }

        public override ITreeNode GenerateNewNode()
        {
            throw new System.NotImplementedException();
        }

        protected ITreeNode GetNewNode(IPosition position)
        {
            ITreeNode closestNode = FindClosestNode(position);
            ITreeNode newNode = Steer(position, closestNode);
            if (_collisionManager.IsPathBetweenPointsFree(newNode, closestNode))
            {
                newNode.Parent = closestNode;
                newNode.CostToParent = newNode.Distance(closestNode);
            }

            return newNode;
        }
    }
}
