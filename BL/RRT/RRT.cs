using BL.Base;
using BL.Base.Interfaces;
using Data.Data;
using System;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseRrtSearchEngine
    {
        private int numberOfSamples;
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
            numberOfSamples = 200;
        }

        public override IObservable<TreeLine> GenerateNextStep()
        {
            throw new NotImplementedException();
        }

        public override void Subscript(IObserver_RRT observer)
        {
            throw new NotImplementedException();
        }

        public override IObservable<TreeLine> UpdateTree(Position position)
        {
            throw new NotImplementedException();
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
