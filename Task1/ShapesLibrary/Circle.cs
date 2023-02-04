using System;

namespace ShapesLibrary;

public class Circle : IShape
{
    private double _radius;
    public double Radius
    {
        get => _radius;
        set
        {
            if (value >= 0)
            {
                _radius = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                        "Radius", "Radius can't be less than zero");
            }
        }
    }

    public Circle() {  }
    
    public double CalculateSquare()
    {
        return Math.PI * Radius * Radius;
    }
}