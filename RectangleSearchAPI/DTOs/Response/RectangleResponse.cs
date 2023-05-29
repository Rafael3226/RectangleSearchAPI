using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.DTOs.Response
{
    public class RectangleResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<CoordinateResponse> Coordinates { get; set; }

        internal static RectangleResponse FromRectangle(Rectangle rectangle)
        {
            return new RectangleResponse()
            {
                Id = rectangle.Id,
                Name = rectangle.Name,
                Coordinates = FromCoordinates(rectangle.Coordinates)
            };
        }
        internal static ICollection<RectangleResponse> FromRectangles(ICollection<Rectangle> rectangles)
        {
            ICollection<RectangleResponse> rectangleResponses= new List<RectangleResponse>();
            foreach (Rectangle rectangle in rectangles)
            {
                rectangleResponses.Add(FromRectangle(rectangle));
            }
            return rectangleResponses;
        }
        private static ICollection<CoordinateResponse> FromCoordinates(ICollection<Coordinate> coordinates)
        {
            ICollection<CoordinateResponse> coordinatesResponse = new List<CoordinateResponse>();

            foreach (Coordinate coordinate in coordinates)
            {
                coordinatesResponse.Add(CoordinateResponse.FromCoordinate(coordinate));
            }

            return coordinatesResponse;
        }
    }
}
