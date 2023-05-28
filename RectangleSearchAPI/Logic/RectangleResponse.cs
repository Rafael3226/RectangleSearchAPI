using RectangleSearchAPI.Models;

namespace RectangleSearchAPI.Logic
{
    public class RectangleResponse
    {
        public Guid RectangleId { get; set; }
        public CoordinateModel TopLeft { get; set; }
        public CoordinateModel BottomRight { get; set; }

        public RectangleResponse(Guid rectangleId, CoordinateModel topLeft, CoordinateModel bottomRight)
        {
            RectangleId = rectangleId;
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

    }
}
