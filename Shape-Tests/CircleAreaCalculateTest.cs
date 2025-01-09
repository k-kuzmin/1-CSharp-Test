using Shape_Library;
using Shape_Library.Shapes;

namespace Shape_Tests;

public class CircleAreaCalculateTest
{
    [Test]
    public void AreaIsEqualPI()
    {
        var handler = CreateShare(1);
        double resultArea = handler.CalculateArea();
        Assert.That(resultArea, Is.EqualTo(Math.PI).Within(5));
    }
    
    [Test]
    public void AreaIsGreaterPI()
    {
        var handler = CreateShare(2);
        double resultArea = handler.CalculateArea();
        Assert.That(resultArea, Is.GreaterThan(Math.PI));
    }
    
    [Test]
    public void AreaIsLessPI()
    {
        var handler = CreateShare(0.5);
        double resultArea = handler.CalculateArea();
        Assert.That(resultArea, Is.LessThan(Math.PI));
    }

    [Test]
    public void InvalidRadiusIsZero()
    {
        var handler = CreateShare(0);
        Assert.Throws<ArgumentException>(() => handler.CalculateArea());
    }

    [Test]
    public void InvalidRadiusIsNegative()
    {
        var handler = CreateShare(-1);
        Assert.Throws<ArgumentException>(() => handler.CalculateArea());
    }

    private IShapeAreaHandler CreateShare(double radius)
    {
        return new CircleHandler(new Circle(radius));
    }
}