using Data;
using System;
using System.Collections.Generic;

namespace MotionCalculator
{
    public abstract class Agent : AgentBase, IAgent
    {
        protected Agent(IPosition rootCoordinates, IPosition goalCoordinates, int velocity) : base(rootCoordinates, goalCoordinates, velocity)
        {
        }

        public IObservable<ITreeNode> GetNewNodesObservable(uint nodeCount)
        {
            throw new NotImplementedException();
        }

        public IObservable<IEnumerable<ITreeNode>> GetPathToGoal()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITreeNode> GetUpdateNodeObs()
        {
            throw new NotImplementedException();
        }

        public SearchState Pause()
        {
            throw new NotImplementedException();
        }

        public SearchState Restart()
        {
            throw new NotImplementedException();
        }

        public SearchState StopSearch()
        {
            throw new NotImplementedException();
        }
    }
}