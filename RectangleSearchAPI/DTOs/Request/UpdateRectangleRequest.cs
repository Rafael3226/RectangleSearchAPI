using RectangleSearchAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.DTOs.Request
{
    public class UpdateRectangleRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(4)]
        [MinLength(4)]
        public ICollection<UpdateCoordinateRequest> Coordinates { get; set; }
        public UpdateRectangleRequest()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Coordinates = new List<UpdateCoordinateRequest>();
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle()
            {
                Id = Id,
                Name = Name,
                Coordinates = ToCoordinates()
            };
        }
        private ICollection<Coordinate> ToCoordinates()
        {
            ICollection<Coordinate> newCoordinates = new List<Coordinate>();
            HashSet<string> coordinatesSet = new HashSet<string>();

            foreach (UpdateCoordinateRequest coordinate in Coordinates)
            {
                if (coordinatesSet.Add($"{coordinate.X},{coordinate.Y}"))
                {
                    newCoordinates.Add(coordinate.ToCoordinate(Id));
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
