using BL.Base;
using Data.Data;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseSearchEngine
    {
        private int numberOfSamples;
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
            numberOfSamples = 200;
        }

        protected override Node GetNewNode(Position position)
        {
                //Node randNode = GenerateNewNode();
                Node closestNode = FindClosestNode(position);
                Node newNode = Steer(position, closestNode);
                if (collisionManager.IsPathBetweenPointsFree(newNode, closestNode))
                {
                    newNode.Parent = closestNode;
                    newNode.CostToParent = Misc.Distance(newNode, closestNode);
                }

            return newNode;
        }
    }
}
