
using System;
using Xunit;

using ShapesLibrary;
using System.Resources;

namespace UnitTests;

public class TestCircle
{
    [Fact]
    public void TestBasic()
    {
        var circle = new Circle { Radius = 1 };
        var result = circle.CalculateSquare();
        Assert.Equal(result, Math.PI);
    }

    [Fact]
    public void TestNegativeRadius()
    {
        Action act = () => new Circle { Radius = -1 };
        var ex = Record.Exception(act);
        Assert.IsType<ArgumentOutOfRangeException>(ex);
    }
}