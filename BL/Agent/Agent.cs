using DiplomkaBartozel.Interfaces;
using System;
using Data.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiplomkaBartozel.Base.Agent
{
    class Agent : AgentBase, IAgent
    {
        private ISearchEngine searchEngine;

        public void GenerateSearch()
        {
            searchEngine.StartSearch();
        }

        public override void Move()
        {
            //will be implemented with alg for dynamic planning RRTx
        }

        public Agent(Position rootCoordinates, Position goalCoordinates, int velocity, ISearchEngine searchEngine) : base(rootCoordinates, goalCoordinates, velocity)
        {
            this.searchEngine = searchEngine;
        }

    }
}
