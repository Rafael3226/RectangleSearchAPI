using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Logic
{
    public class BarycentricCoordinates
    {
        public static bool IsPointInsideQuadrilateral(Coordinate point, Rectangle rectangle)
        {
            // Get the coordinates of the rectangle vertices
            Coordinate A = rectangle.Coordinates.ElementAt(0);
            Coordinate B = rectangle.Coordinates.ElementAt(1);
            Coordinate C = rectangle.Coordinates.ElementAt(2);
            Coordinate D = rectangle.Coordinates.ElementAt(3);

            // Calculate the barycentric coordinates of the point with respect to the rectangle vertices
            double wAB = calculateBarycentricCoordinate(point, A, B, C);
            double wBC = calculateBarycentricCoordinate(point, B, C, D);
            double wCD = calculateBarycentricCoordinate(point, C, D, A);
            double wDA = calculateBarycentricCoordinate(point, D, A, B);

            // Check if the barycentric coordinates are all positive
            return (wAB >= 0 && wBC >= 0 && wCD >= 0 && wDA >= 0);
        }
        private static double calculateBarycentricCoordinate(Coordinate point, Coordinate vertex1, Coordinate vertex2, Coordinate vertex3)
        {
            double numerator = ((vertex2.Y - vertex3.Y) * (point.X - vertex3.X)) + ((vertex3.X - vertex2.X) * (point.Y - vertex3.Y));
            double denominator = ((vertex2.Y - vertex3.Y) * (vertex1.X - vertex3.X)) + ((vertex3.X - vertex2.X) * (vertex1.Y - vertex3.Y));
            return numerator / denominator;
        }
    }
}
