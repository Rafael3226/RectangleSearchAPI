using RectangleSearchAPI.Logic;
using RectangleSearchAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleSearchAPI.Test.Logic
{
    public class BarycentricCoordinatesTests
    {
        [Fact]
        public void Is_Coordinate_Inside_Quadrilateral()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();
            
            rectangle.Coordinates.Add(new Coordinate(0,0,rectangle));
            rectangle.Coordinates.Add(new Coordinate(1,0,rectangle));
            rectangle.Coordinates.Add(new Coordinate(0,1,rectangle));
            rectangle.Coordinates.Add(new Coordinate(1,1,rectangle));

            Coordinate pointInside = new Coordinate() { X=0.5,Y=0.5 };
            Coordinate pointOutside = new Coordinate() { X = 0.5, Y = -0.5 };

            // Act
            bool pointInsideResult = BarycentricCoordinates.IsPointInsideQuadrilateral(pointInside, rectangle);
            bool pointOutsideResult = BarycentricCoordinates.IsPointInsideQuadrilateral(pointOutside, rectangle);

            // Assert
            Assert.True(pointInsideResult);
            Assert.False(pointOutsideResult);
        }
        [Fact]
        public void Is_Coordinate_Inside_Rotated_Quadrilateral()
        {
            // Arrange
            Rectangle rectangle = new Rectangle();
            rectangle.Coordinates.Add(new Coordinate(1, 1, rectangle));
            rectangle.Coordinates.Add(new Coordinate(-1, -1, rectangle));
            rectangle.Coordinates.Add(new Coordinate(-1, 1, rectangle));
            rectangle.Coordinates.Add(new Coordinate(1, -1, rectangle));


            Coordinate pointInside = new Coordinate() { X = 0, Y = 0 };
            Coordinate pointOutside = new Coordinate() { X = 0, Y = 2 };

            // Act
            bool pointInsideResult = BarycentricCoordinates.IsPointInsideQuadrilateral(pointInside, rectangle);
            bool pointOutsideResult = BarycentricCoordinates.IsPointInsideQuadrilateral(pointOutside, rectangle);

            // Assert
            Assert.True(pointInsideResult);
            Assert.False(pointOutsideResult);
        }

    }
}
