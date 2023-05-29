using Microsoft.AspNetCore.Mvc;
using RectangleSearchAPI.Data;
using RectangleSearchAPI.DTOs.Request;
using RectangleSearchAPI.DTOs.Response;
using RectangleSearchAPI.Exceptions;
using RectangleSearchAPI.Models;
using System.Net.Mime;

namespace RectangleSearchAPI.Controllers
{
    [Route("api/rectangle")] // api/rectangle
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        private readonly SqlServerDbContext dbContext;
        public RectangleController(SqlServerDbContext dbContex)
        {
            dbContext = dbContex;  
        }

        #region GET Actions

        /// <summary>
        /// Returns all the retangles.
        /// </summary>
        /// <returns>List of all the rectangles</returns>
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRectangles([FromQuery] int count = 5)
        {
            ICollection<Rectangle> rectangles = await dbContext.GetRectanglesAsync(count);

            ICollection<RectangleResponse> response = RectangleResponse.FromRectangles(rectangles);

            return Ok(response);
        }

        /// <summary>
        /// Search a rectangle.
        /// </summary>
        /// <param name="id">Rectangle ID</param>
        /// <returns>The Rectangle with the ID</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRectangle([FromQuery]Guid id)
        {
            try
            {
                Rectangle rectangle = await dbContext.FindRectangleAsync(id);
                RectangleResponse response = RectangleResponse.FromRectangle(rectangle);
                return Ok(response);
            } 
            catch (ItemNotFoundException ex)
            {
                return NotFound(new ErrorResponse(ex));
            }
        }

        #endregion

        #region POST Actions

        /// <summary>
        /// Save a new rectangle
        /// </summary>
        /// <param name="rectangleRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AddRectangle(RectangleRequest rectangleRequest)
        {
            try {
                Rectangle rectangle = rectangleRequest.ToRectangle(); 
                dbContext.AddRectangleAsync(rectangle);
                await dbContext.SaveChangesAsync();

                RectangleResponse response = RectangleResponse.FromRectangle(rectangle);
                string resourceUri = Url.Action("GetRectangle", new { id = rectangle.Id }) ?? string.Empty;

                return Created(resourceUri, response);
            }
            catch(ArgumentException ex)
            {
                return UnprocessableEntity(new ErrorResponse(ex));
            }
            
        }

        #endregion

        #region PUT Actions

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> UpdateRectangle(UpdateRectangleRequest rectangleRequest)
        {
            try
            {
                Rectangle rectangle = rectangleRequest.ToRectangle();
                dbContext.UpdateRectangleAsync(rectangle);
                await dbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return UnprocessableEntity(new ErrorResponse(ex));
            }

        }

        #endregion
    }
}
