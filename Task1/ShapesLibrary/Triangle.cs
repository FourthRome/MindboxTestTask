using System;

namespace ShapesLibrary;

/// <summary>
/// Class <c>Triangle</c> implements a triangle specified by its three sides.
/// </summary>
/// <remarks>
/// To satisfy the triangle inequality triangle's sides' properties are
/// read-only. That's also why object initializer syntax is not supported,
/// and a single constructor is given instead. Differing implementations
/// are possible.
/// </remarks>
public class Triangle : TriangleBase
{
    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }
    public override double Area => _area;

    public Triangle(double sideA, double sideB, double sideC)
    {
        ValidateSides(sideA, sideB, sideC);
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        _area = CalculateArea(sideA, sideB, sideC);
    }

    // Private methods and fields
    private static void ValidateSides(double sideA, double sideB, double sideC)
    {
        // Check that sides are non-negative
        var argName = "";
        if (sideA < 0) argName = nameof(sideA);
        if (sideB < 0) argName = nameof(sideB);
        if (sideC < 0) argName = nameof(sideC);
        if (argName != "")
        {
            throw new ArgumentOutOfRangeException(
                    argName, "Triangle's side cannot be negative");
        }

        // Check that sides satisfy the triangle inequality
        if ((sideA + sideB >= sideC &&
            sideB + sideC >= sideA &&
            sideC + sideA >= sideB) != true)
        {
            throw new ArgumentOutOfRangeException(
                    nameof(sideA),
                    "Arguments do not satisfy the triangle inequality");
        }
    }

    private static double CalculateArea(double sideA, double sideB, double sideC)
    {
        var a_sqr = sideA * sideA;
        var b_sqr = sideB * sideB;
        var c_sqr = sideC * sideC;
        if (a_sqr + b_sqr == c_sqr) return sideA * sideB / 2;
        if (b_sqr + c_sqr == a_sqr) return sideB * sideC / 2;
        if (c_sqr + a_sqr == b_sqr) return sideC * sideA / 2;
        var semiperim = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(
                semiperim * (semiperim - sideA)
                * (semiperim - sideB) * (semiperim - sideC));
    }

    private double _area;
}
