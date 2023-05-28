using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Models
{
    public record RectangleModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TopLeftId { get; set; }
        [Required]
        public Guid BottomRightId { get; set; }

        // Navigation property
        public CoordinateModel TopLeftCoordinate { get; set; }
        public CoordinateModel BottomRightCoordinate { get; set; }

        public RectangleModel(CoordinateModel topLeftCoordinate, CoordinateModel bottomRightCoordinate)
        {
            TopLeftCoordinate = topLeftCoordinate;
            BottomRightCoordinate = bottomRightCoordinate;
            TopLeftId = topLeftCoordinate.Id;
            BottomRightId = bottomRightCoordinate.Id;
        }
    }
}
