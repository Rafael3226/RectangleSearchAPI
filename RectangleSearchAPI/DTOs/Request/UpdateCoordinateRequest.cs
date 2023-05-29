using RectangleSearchAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.DTOs.Request
{
    public class UpdateCoordinateRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
        internal Coordinate ToCoordinate(Guid idRectangle)
        {
            return new Coordinate()
            {
                Id = Id,
                X = X,
                Y = Y,
                IdRectangle = idRectangle
            };
        }
    }
}