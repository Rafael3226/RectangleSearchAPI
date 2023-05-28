using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Logic
{
    public record Coordinate : ICoordinate
    {
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
    }
}
