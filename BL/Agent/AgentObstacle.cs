using Data.Data;

namespace BL.Agent
{
    class AgentObstacle : AgentBase
    {
        public AgentObstacle(IPosition rootCoordinates, IPosition goalCoordinates, int velocity) : base(rootCoordinates, goalCoordinates, velocity)
        {

        }
    }
}
