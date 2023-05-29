using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using RectangleSearchAPI.Controllers;
using RectangleSearchAPI.Data;
using RectangleSearchAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleSearchAPI.Test.Controllers
{
    public class RectangleControllerTests
    {
        [Fact]
        public async void GetRectangles_Returns_Empty_List()
        {
            // Arrange
            int count = 5;
            IEnumerable<Rectangle> fakeRectangles = A.CollectionOfDummy<Rectangle>(count).AsEnumerable();
            IEnumerable<Coordinate> fakeCoordinates = A.CollectionOfDummy<Coordinate>(20).AsEnumerable();

            var dbContex = A.Fake<SqlServerDbContext>();
            A.CallTo(() => dbContex.GetRectanglesAsync(5)).Returns(Task.FromResult(fakeRectangles));
            RectangleController rectangleController = new RectangleController(dbContex);
            // Act
            var actionResult = await rectangleController.GetRectangles();
            // Assert
            var result = actionResult as OkObjectResult;
            /*var returnRecipes = actionResult.ExecuteResultAsync();

            Assert.Equal(count, actionResult.Count())*/
        }
    }
}
