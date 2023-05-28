using RectangleSearchAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Logic
{
    public record CoordinatesPair
    {
        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public Coordinate[] Coordinates { get; set; }

        public CoordinatesPair()
        {
            Coordinates = new Coordinate[2];
        }
    }
}
