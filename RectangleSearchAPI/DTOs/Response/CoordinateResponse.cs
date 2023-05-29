using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.DTOs.Response
{
    public class CoordinateResponse
    {
        public Guid Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        internal static CoordinateResponse FromCoordinate(Coordinate coordinates)
        {
            return new CoordinateResponse()
            {
                Id = coordinates.Id,
                X = coordinates.X,
                Y = coordinates.Y
            };
        }
    }
}