using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Logic
{
    public record Rectangle:CoordinatesPair
    {

        public Rectangle(Coordinate[] coordinates)
        {
            if (coordinates[0].X == coordinates[1].X ||
                    coordinates[0].Y == coordinates[1].Y)
            {
                throw new ArgumentException("Coordinates must have different X and Y values.");
            }
            Coordinates = coordinates;
        }

        public CoordinateModel getTopLeft()
        {
            bool isFirstLeft = Coordinates[0].X < Coordinates[1].X;
            bool isFirstTop = Coordinates[0].Y > Coordinates[1].Y;

            double x, y;
            if (isFirstLeft) x = Coordinates[0].X;
            else x = Coordinates[1].Y;
            if (isFirstTop) y = Coordinates[0].Y;
            else y = Coordinates[1].Y;

            return new CoordinateModel(x, y);
        }

        public CoordinateModel getBottomRight()
        {
            bool isFirstRight = Coordinates[0].X > Coordinates[1].X;
            bool isFirstBottom = Coordinates[0].Y < Coordinates[1].Y;

            double x, y;
            if (isFirstRight) x = Coordinates[0].X;
            else x = Coordinates[1].Y;
            if (isFirstBottom) y = Coordinates[0].Y;
            else y = Coordinates[1].Y;

            return new CoordinateModel(x,y);
        }
    }
}
