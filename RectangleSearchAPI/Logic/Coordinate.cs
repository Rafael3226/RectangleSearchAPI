using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Logic
{
    public class Coordinate
    {
        [Required]
        public double X { get; set; }
        [Required]
        public double Y { get; set; }
    }
}
