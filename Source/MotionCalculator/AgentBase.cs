using Data;

namespace MotionCalculator
{
    public abstract class AgentBase : SearchArea
    {
        public bool IsMoving => _isMoving;
        private bool _isMoving;

        public IPosition GoalCoordinates { get; set; }
        public IPosition RootCoordinates { get; set; }
        public int Velocity { get; set; }

        public AgentBase(IPosition rootCoordinates, IPosition goalCoordinates, int velocity) : base(rootCoordinates)
        {
            GoalCoordinates = goalCoordinates;
            RootCoordinates = rootCoordinates;
            Velocity = velocity;
            _isMoving = false;
        }
    }
}
