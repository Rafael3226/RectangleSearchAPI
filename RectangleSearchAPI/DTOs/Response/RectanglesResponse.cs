namespace RectangleSearchAPI.DTOs.Response
{
    public class RectanglesResponse
    {
        public double X { get; set; }
        public double Y { get; set; }
        public ICollection<RectangleResponse> Rectangles { get; set; }
    }
}
