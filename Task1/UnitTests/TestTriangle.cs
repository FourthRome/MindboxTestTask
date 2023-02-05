using System;
using Xunit;

using ShapesLibrary;

namespace UnitTests;

public class TestTriangle
{
    [Theory]
    [InlineData(3.0, 4.0, 5.0, 6.0)]  // right triangle
    [InlineData(6.0, 5.0, 5.0, 12.0)]  // regular triangle
    [InlineData(2.0, 1.0, 1.0, 0.0)]  // degenerate triangle
    public void TestBasic(double a, double b, double c, double expected)
    {
        var triangle = new Triangle(a, b, c);
        Assert.Equal(expected, triangle.Area, 7);
    }

    [Theory]
    [InlineData(-3, 4, 5)]  // negative side length
    [InlineData(1, 1, 3)]  // violates the triangle inequality
    public void TestIncorrectSides(double a, double b, double c)
    {
        Action act = () => new Triangle(a, b, c);
        var ex = Record.Exception(act);
        Assert.IsType<ArgumentOutOfRangeException>(ex);
    }
}
