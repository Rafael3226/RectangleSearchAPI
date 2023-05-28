using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace RectangleSearchAPI.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ErrorController:ControllerBase
    {
        /// <summary>
        /// Log an internal error
        /// </summary>
        /// <returns>Context, Stack Trace and Error Messge</returns>
        [HttpGet("/error")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            string? stackTrace = context?.Error.StackTrace;
            string? errorMessage = context?.Error.Message;
            // log this error somewhere
            return Problem();
        }
    }
}
