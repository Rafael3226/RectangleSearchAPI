namespace RectangleSearchAPI.Logic
{
    public interface ICoordinate
    {
        double X { get; set; }
        double Y { get; set; }

        bool Equals(Coordinate? other);
        bool Equals(object? obj);
        int GetHashCode();
        string ToString();
    }
}