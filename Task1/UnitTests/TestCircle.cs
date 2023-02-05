
using System;
using Xunit;

using ShapesLibrary;

namespace UnitTests;

public class TestCircle
{
    [Fact]
    public void TestBasic()
    {
        var circle = new Circle { Radius = 1 };
        Assert.Equal(Math.PI, circle.Area);
    }

    [Fact]
    public void TestNegativeRadius()
    {
        Action act = () => new Circle { Radius = -1 };
        var ex = Record.Exception(act);
        Assert.IsType<ArgumentOutOfRangeException>(ex);
    }
}
