using RectangleSearchAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.DTOs.Request
{
    public class CoordinatesRequest
    {
        [Required]
        public ICollection<CoordinateRequest> Coordinates { get; set; }

        public ICollection<Coordinate> ToCoordinates()
        {
            ICollection<Coordinate> newCoordinates = new List<Coordinate>();
            HashSet<string> coordinatesSet = new HashSet<string>();

            foreach (CoordinateRequest coordinate in Coordinates)
            {
                if (coordinatesSet.Add($"{coordinate.X},{coordinate.Y}"))
                {
                    newCoordinates.Add(coordinate.ToCoordinate(Guid.Empty));
                }
                else
                {
                    throw new ArgumentException("All Coordinates must be diferent.");
                }
            }
            return newCoordinates;
        }

    }
}
