using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RectangleSearchAPI.Models
{
    public class Coordinate
    {
        [Key]
        public Guid Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public Guid IdRectangle { get; set; }
        
        public Rectangle Rectangle { get; set; }
        
    }
}
