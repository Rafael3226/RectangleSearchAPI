using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Models
{
    public record Rectangle
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Coordinate> Coordinates { get; set; }

        public Rectangle(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Coordinates = new List<Coordinate>();
        }

        public Rectangle()
        {
            Id = Guid.Empty;
            Name = string.Empty;
            Coordinates = new List<Coordinate>();
        }
    }
}
