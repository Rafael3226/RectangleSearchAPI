using RectangleSearchAPI.Logic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RectangleSearchAPI.Models
{
    public class CoordinateModel: Coordinate
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public RectangleModel Rectangle { get; set; }
        public CoordinateModel(double x, double y)
        {
            X= x;
            Y= y;
            Rectangle = new RectangleModel();
        }

        public CoordinateModel(RectangleModel rectangle)
        {
            Rectangle = rectangle;
        }
    }
}
