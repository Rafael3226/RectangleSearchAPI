using RectangleSearchAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace RectangleSearchAPI.Logic
{
    public class CoordinatesPair
    {
        [Required]
        [MaxLength(2)]
        [MinLength(2)]
        public Coordinate[] Coordinates { get; set; }

        public CoordinatesPair()
        {
            Coordinates = new Coordinate[2];
        }
        public RectangleModel ToRectangleModel()
        {
            var (xLeft, xRight, yTop, yBottom) = NormaliceCoordinates();

            CoordinateModel TopLeftCoordinate = new CoordinateModel(xLeft, yTop);
            CoordinateModel BottomRightCoordinate = new CoordinateModel(xRight, yBottom);

            return new RectangleModel(TopLeftCoordinate, BottomRightCoordinate);

        }
        private (double xLeft, double xRight, double yTop, double yBottom) NormaliceCoordinates()
        {
            var (x0, x1, y0, y1) = DeconstructCoordinates();
            if (x0 == x1 || y0 == y1)
            {
                throw new ArgumentException("Coordinates must have different X and Y values.");
            }

            double xLeft = Math.Min(x0, x1);
            double xRight = Math.Max(x0, x1);
            double yTop = Math.Max(y0, y1);
            double yBottom = Math.Min(y0, y1);

            return (xLeft, xRight, yTop, yBottom);
        }
        internal (double x0, double x1, double y0, double y1) DeconstructCoordinates()
        {
            return ( Coordinates[0].X, Coordinates[1].X, Coordinates[0].Y, Coordinates[1].Y );
        }
    }
}
