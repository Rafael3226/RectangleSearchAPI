using RectangleSearchAPI.Logic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RectangleSearchAPI.Models
{
    public record RectangleModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [JsonIgnore]
        public Guid TopLeftId { get; set; }
        [Required]
        [JsonIgnore]
        public Guid BottomRightId { get; set; }

        // Navigation property

        public CoordinateModel TopLeftCoordinate { get; set; }

        public CoordinateModel BottomRightCoordinate { get; set; }

        public RectangleModel()
        {
            TopLeftCoordinate = new CoordinateModel(this);
            BottomRightCoordinate = new CoordinateModel(this);
        }

        public RectangleModel(CoordinateModel topLeftCoordinate, CoordinateModel bottomRightCoordinate)
        {
            TopLeftCoordinate = topLeftCoordinate;
            BottomRightCoordinate = bottomRightCoordinate;
        }

        internal void Deconstruct(out CoordinateModel topLeftCoordinate, out CoordinateModel bottomRightCoordinate)
        {
            topLeftCoordinate = TopLeftCoordinate;
            bottomRightCoordinate = BottomRightCoordinate;
        }
    }
}
