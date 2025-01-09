using Shape_Library;
using Shape_Library.Shapes;

namespace Shape_Tests;

public class TriangleAreaCalculateTest
{
    [Test]
    public void AreaIsEqual()
    {
        var handler = CreateShare(3,4,5);
        double resultArea = handler.CalculateArea();
        Assert.That(resultArea, Is.EqualTo(6).Within(5));
    }

    [Test]
    public void InvalidTriangle_1()
    {
        var handler = CreateShare(-1,2,3);
        Assert.Throws<ArgumentException>(() => handler.CalculateArea());
    }

    [Test]
    public void InvalidTriangle_2()
    {
        var handler = CreateShare(1,2,3);
        Assert.Throws<ArgumentException>(() => handler.CalculateArea());
    }

    private IShapeAreaHandler CreateShare(double a, double b, double c)
    {
        return new TriangleHandler(new Triangle(a,b,c));
    }
}