using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomkaBartozel.Base.Agent
{
    static class AgentManager
    {
        public static List<AgentObstacle> AgentObstacles { get; private set; }
        public static List<Agent> Agents { get; private set; }

        static AgentManager()
        {
            AgentObstacles = new List<AgentObstacle>();
            Agents = new List<Agent>();
        }

        public static void AddAgentsObstacles(AgentObstacle ao)
        {
            AgentObstacles.Add(ao);
        }

        public static void AddAgent(Agent a)
        {
            Agents.Add(a);
        }
    }
}
