using Newtonsoft.Json;
using RectangleSearchAPI.Logic;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Models
{
    public record CoordinateModel: Coordinate
    {
        [Required]
        public Guid Id { get; set; }
        public RectangleModel Rectangle { get; set; }

        public CoordinateModel(double x, double y, RectangleModel rectangle)
        {
            X= x;
            Y= y;
            Rectangle = rectangle;
        }


    }
}
