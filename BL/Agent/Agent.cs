using DiplomkaBartozel.Interfaces;
using System;
using Data.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiplomkaBartozel.Base.Agent
{
    class Agent : AgentBase
    {
        private ISearchEngine searchEngine;

        public override void GenerateSearch()
        {
            throw new NotImplementedException();
        }

        public Agent(Position rootCoordinates, Position goalCoordinates, int velocity, ISearchEngine searchEngine) : base(rootCoordinates, goalCoordinates, velocity)
        {
            this.searchEngine = searchEngine;
        }

    }
}
