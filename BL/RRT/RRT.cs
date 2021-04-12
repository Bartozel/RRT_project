using BL.Base;
using BL.Base.Interfaces;
using Data;
using Data.Data;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Navigation;

namespace DiplomkaBartozel.RRT
{
    class RRT : BaseRrtSearchEngine
    {
        public RRT(Position startPos, Position goalPos) : base(startPos, goalPos)
        {

        }

        public override IObservable<TreeLine> GenerateNextStep(int amount)
        {
            return Observable.Create<TreeLine>(o =>
            {
                for (int x = 0; x <= amount; x++)
                {
                    var node = GenerateNextStep();
                    o.OnNext(node.ToLine());
                }

                return Disposable.Empty;
            });
        }

        protected Node GenerateNextStep()
        {
            var position = this.GenerateNewPosition();
            var node = GetNewNode(position);
            this.tree.Insert(node);
            return node;
        }

        public override IObservable<TreeLine> UpdateTree(Position position)
        {
            return new List<TreeLine>().ToObservable();
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
