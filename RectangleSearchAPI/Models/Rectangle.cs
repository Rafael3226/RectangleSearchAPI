using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Models
{
    public record Rectangle
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Coordinate> Coordinates { get; set; }

    }
}
