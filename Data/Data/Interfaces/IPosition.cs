namespace Data
{
    public interface IPosition
    {
        int XCoordinate { get; }
        int YCoordinate { get; }

        double Distance(IPosition node);
    }
}
