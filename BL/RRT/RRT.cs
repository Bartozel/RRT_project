using Data.Data;
using DiplomkaBartozel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseSearchEngine
    {
        private int numberOfSamples;
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {
            numberOfSamples = 200;
        }

        protected override Node Process(Node node)
        {
                //Node randNode = GenerateNewNode();
                Node closestNode = FindClosestNode(node);
                Node newNode = Steer(node, closestNode);
                if (collisionManager.IsPathBetweenPointsFree(newNode, closestNode))
                {
                    newNode.Parent = closestNode;
                    newNode.CostToParent = Distance(newNode, closestNode);
                }

            return newNode;
        }
    }
}
