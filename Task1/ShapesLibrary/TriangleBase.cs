namespace ShapesLibrary;

/// <summary>
/// Class <c>TriangleBase</c> is a root class for different implementations
/// of <c>IShape</c> triangles.
/// </summary>
public abstract class TriangleBase : IShape
{
    public abstract double Area { get; }
}
