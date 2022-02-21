using Data.Data;

namespace BL.Agent
{
    public abstract class AgentBase : SearchArea
    {
        public bool IsMooving => isMooving;
        private bool isMooving;

        public IPosition GoalCoordinates { get; set; }
        public IPosition RootCoordinates { get; set; }
        public int Velocity { get; set; }

        public AgentBase(IPosition rootCoordinates, IPosition goalCoordinates, int velocity) : base(rootCoordinates)
        {
            GoalCoordinates = goalCoordinates;
            RootCoordinates = rootCoordinates;
            Velocity = velocity;
            this.isMooving = false;
        }
    }
}
