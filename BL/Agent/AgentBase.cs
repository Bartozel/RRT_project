using Data.Data;

namespace BL.Agent
{
    public abstract class AgentBase : SearchArea
    {
        public bool IsMooving => isMooving;
        private bool isMooving;

        public Position GoalCoordinates { get; set; }
        public Position RootCoordinates { get; set; }
        public int Velocity { get; set; }

        public AgentBase(Position rootCoordinates, Position goalCoordinates, int velocity) : base(rootCoordinates)
        {
            GoalCoordinates = goalCoordinates;
            RootCoordinates = rootCoordinates;
            Velocity = velocity;
            this.isMooving = false;
        }

        public abstract void Move();
    }
}
