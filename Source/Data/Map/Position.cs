﻿namespace Data
{
    public class Position
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

        public Position(Position position) : base()
        {
            XCoordinate = position.XCoordinate;
            YCoordinate = position.YCoordinate;
        }
    }
}
