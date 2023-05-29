using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RectangleSearchAPI.Data;
using RectangleSearchAPI.DTOs.Request;
using RectangleSearchAPI.DTOs.Response;
using RectangleSearchAPI.Logic;
using RectangleSearchAPI.Models;
using System.Collections.Generic;
using System.Net.Mime;

namespace RectangleSearchAPI.Controllers
{
    [Route("api/coordinate")] // api/coordinate
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        private readonly SqlServerDbContext dbContext;
        public CoordinateController(SqlServerDbContext dbContex)
        {
            dbContext = dbContex;
        }

        #region POST Actions

        [HttpPost]
        [Route("rectangles")]
        public async Task<IActionResult> GetRectanglesFromCoordinates(CoordinatesRequest coordinatesRequest)
        {
            ICollection<Coordinate> coordinates = coordinatesRequest.ToCoordinates();
            ICollection<Rectangle> rectangles = await dbContext.GetRectanglesAsync();

            CoordinatesResponse response = new CoordinatesResponse();

            foreach (Coordinate coordinate in coordinates)
            {
                ICollection<Rectangle> selectedRectangles = new List<Rectangle>();
                foreach (Rectangle rectangle in rectangles)
                {
                    if (BarycentricCoordinates.IsPointInsideQuadrilateral(coordinate,rectangle)) 
                    {
                        selectedRectangles.Add(rectangle);
                    }
                }
                response.AddRectangles(coordinate, selectedRectangles);
            }

            return Ok(response);
        }

        #endregion

    }
}
