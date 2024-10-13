namespace Data
{
    public class Position : IPosition
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public Position()
        {
            XCoordinate = 0;
            YCoordinate = 0;
        }

        public Position(int xCoordinate, int yCoordinate) : base()
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }

        public Position(IPosition position) : base()
        {
            XCoordinate = position.XCoordinate;
            YCoordinate = position.YCoordinate;
        }

        public double Distance(IPosition node)
        {
            throw new System.NotImplementedException();
        }
    }
}
