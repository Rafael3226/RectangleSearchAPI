using RectangleSearchAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.DTOs.Request
{
    public class RectangleRequest
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(4)]
        [MinLength(4)]
        public ICollection<CoordinateRequest> Coordinates { get; set; }

        public Rectangle ToRectangle()
        {
            Guid idRectangle = Guid.NewGuid();
            return new Rectangle()
            {
                Id = idRectangle,
                Name = Name,
                Coordinates = ToCoordinates(idRectangle)
            };
        }
        private ICollection<Coordinate> ToCoordinates(Guid idRectangle)
        {
            ICollection<Coordinate> newCoordinates = new List<Coordinate>();
            HashSet<string> coordinatesSet = new HashSet<string>();

            foreach (CoordinateRequest coordinate in Coordinates)
            {
                if (coordinatesSet.Add($"{coordinate.X},{coordinate.Y}"))
                {
                    newCoordinates.Add(coordinate.ToCoordinate(idRectangle));
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
