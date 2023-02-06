using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

using ShapesLibrary;

namespace UnitTests;

public class TestIShape
{
    /// <remarks>
    /// This one could and should be written more eloquently,
    /// I just wanted to flex my familiarity with AAA or something, idk.
    /// </remarks>
    [Fact]
    public void TestBasic()
    {
        // Arrange
        var circle = new Circle(1.0);
        var triangle = new Triangle(3.0, 4.0, 5.0);
        var shapes = new Collection<IShape>
        {
            circle,
            triangle
        };

        // Act
        List<System.Exception> exceptions = new();
        foreach (var item in shapes)
        {
            exceptions.Add(Record.Exception(() => item.Area));
        }

        // Assert
        foreach (var ex in exceptions) Assert.Null(ex);
    }
}
