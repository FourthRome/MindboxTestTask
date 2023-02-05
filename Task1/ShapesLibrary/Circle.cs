using System;

namespace ShapesLibrary;

public class Circle : IShape
{
    public double Radius
    {
        get => _radius;
        set
        {
            if (value >= 0) _radius = value;
            else
            {
                throw new ArgumentOutOfRangeException(
                        "Radius", "Radius can't be less than zero");
            }
        }
    }
    public double Area => Math.PI * Radius * Radius;

    public Circle() {  }  // allows to use object initializer

    public Circle(double radius) => Radius = radius;
    
    private double _radius;
}
