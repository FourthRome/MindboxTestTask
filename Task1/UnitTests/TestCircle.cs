
using System;
using Xunit;

using ShapesLibrary;

namespace UnitTests;

public class TestCircle
{
    [Fact]
    public void TestBasic()
    {
        Circle circle = new Circle { Radius = 1 };
        Assert.Equal(circle.CalculateSquare(), Math.PI);
    }

    [Fact]
    public void TestNegativeRadius()
    {
        Action act = () => new Circle { Radius = -1 };
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }
}