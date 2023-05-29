using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Seed
{
    public class RectangleGenerator
    {
        private Random random = new Random();

        private static readonly int MAX_VALUE = 1000;
        private static readonly int DELTA_MAX_VALUE = 10;

        public Rectangle GenerateRectangle(string name) 
        { 
            Rectangle rectangle = new Rectangle(name);
            List<Coordinate> coordinates = GenerateCoordinates(rectangle);
            coordinates.ForEach(c => { rectangle.Coordinates.Add(c);  });
            return rectangle;
        }
        private (double x, double y, double deltaX, double deltaY) GenerateRandomValues()
        {
            double x = NextRandom(MAX_VALUE);
            double y = NextRandom(MAX_VALUE);
            double deltaX = NextRandom(DELTA_MAX_VALUE);
            double deltaY = NextRandom(DELTA_MAX_VALUE);

            return (x, y, deltaX, deltaY);
        }
        private List<Coordinate> GenerateCoordinates(Rectangle rectangle)
        {
            (double x, double y, double deltaX, double deltaY) = GenerateRandomValues();
            var coordinates = new List<Coordinate>();
            coordinates.Add(new Coordinate(x, y, rectangle));
            coordinates.Add(new Coordinate(x + deltaX, y, rectangle));
            coordinates.Add(new Coordinate(x, y + deltaY, rectangle));
            coordinates.Add(new Coordinate(x + deltaX, y + deltaY, rectangle));
            return coordinates;
        }
        private double NextRandom(int max)
        {
            return random.NextDouble()*max*2-max;
        }
    }
}
