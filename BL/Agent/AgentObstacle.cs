using Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Base.Agent
{
    class AgentObstacle : AgentBase
    {
        public AgentObstacle(Position rootCoordinates, Position goalCoordinates, int velocity) : base(rootCoordinates, goalCoordinates, velocity)
        {
        }

        public override void GenerateSearch()
        {
            throw new NotImplementedException();
        }
    }
}
