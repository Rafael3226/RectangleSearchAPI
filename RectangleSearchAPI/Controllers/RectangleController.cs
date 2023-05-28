using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RectangleSearchAPI.Data;
using RectangleSearchAPI.Exceptions;
using RectangleSearchAPI.Logic;
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
        private readonly RectangleSearchAPIDbContext dbContext;
        public RectangleController(RectangleSearchAPIDbContext dbContex)
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
            return Ok(await dbContext.GetRectanglesAsync(count));
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
                RectangleModel rectangle = await dbContext.FindRectangleAsync(id);
                return Ok(rectangle);
            } catch (ItemNotFoundException ex)
            {
                return NotFound(new ErrorResponse(ex));
            }
        }

        #endregion

        #region POST Actions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AddRectangle(CoordinatesPair coordinates)
        {
            try {
                RectangleModel rectangleModel = coordinates.ToRectangleModel();
                dbContext.AddRectangleAsync(rectangleModel);
                await dbContext.SaveChangesAsync();

                string resourceUri = Url.Action("GetRectangle", new { id = rectangleModel.Id }) ?? string.Empty;
                return Created(resourceUri, rectangleModel);
            }
            catch(ArgumentException ex)
            {
                return UnprocessableEntity(new ErrorResponse(ex));
            }
            
        }

        #endregion

        #region PUT Actions

        /*[HttpPut]*/

        #endregion
    }
}
