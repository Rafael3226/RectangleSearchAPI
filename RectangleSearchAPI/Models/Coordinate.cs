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

        public Coordinate(double x, double y, Rectangle rectangle)
        {
            X = x;
            Y = y;
            IdRectangle = rectangle.Id;
            Rectangle = rectangle;
        }

        public Coordinate()
        {
            Id= Guid.Empty;
            X = 0; Y= 0;
            Id = Guid.Empty;
            Rectangle = new Rectangle();
        }
    }
}
