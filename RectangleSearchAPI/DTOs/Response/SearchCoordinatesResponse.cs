using RectangleSearchAPI.DTOs.Response;
using RectangleSearchAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.DTOs.Response
{
    public class SearchCoordinatesResponse
    {
        public ICollection<RectanglesResponse> Coordinates { get; set; }

        public SearchCoordinatesResponse()
        {
            Coordinates = new List<RectanglesResponse>();
        }

        internal void AddRectangles(Coordinate coordinate, ICollection<Rectangle> selectedRectangles)
        {
            ICollection<RectangleResponse> rectangles = new List<RectangleResponse>();
            foreach (Rectangle rectangle in selectedRectangles)
            {
                rectangles.Add(RectangleResponse.FromRectangle(rectangle));
            }
            Coordinates.Add(new RectanglesResponse()
            {
                X= coordinate.X,
                Y= coordinate.Y,
                Rectangles=rectangles
            });
        }
    }
}
