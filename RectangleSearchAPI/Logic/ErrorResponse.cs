using Microsoft.AspNetCore.Mvc;

namespace RectangleSearchAPI.Logic
{
    public class ErrorResponse: ProblemDetails
    {
        public ErrorResponse(Exception ex) {
            Type = ex.GetType().Name;
            Title = ex.Source;
            Detail = ex.Message;
            Instance = ex.HResult.ToString();
        }
    }
}
