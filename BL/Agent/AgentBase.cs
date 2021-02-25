using Data.Data;
using DiplomkaBartozel.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DiplomkaBartozel.Base.Agent
{
    abstract class AgentBase : IAgent
    {
        public bool IsMooving => isMooving;
        private bool isMooving;

        public Position GoalCoordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Position RootCoordinates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public AgentBase(Position rootCoordinates, Position goalCoordinates, int velocity)
        {
            GoalCoordinates = goalCoordinates;
            RootCoordinates = rootCoordinates;
            Velocity = velocity;
            this.isMooving = false;
        }

        public abstract void GenerateSearch();
  
        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
