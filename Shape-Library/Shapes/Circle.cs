namespace Shape_Library.Shapes;

public readonly struct Circle
{
    public readonly double Radius;

    public Circle(double radius)
    {
        Radius = radius;
    }
}

public class CircleHandler : IShapeInfo, IShapeAreaHandler
{
    private readonly Circle _shape;
    
    public CircleHandler(Circle shape)
    {
        _shape = shape;
    }
    
    public string GetInfo()
    {
        var result = $"[Круг] Радиус - {_shape.Radius}, S - ";
        
        try
        {
            var s = CalculateArea();
            result += s.ToString("F5");
        }
        catch (Exception e)
        {
            result += e.Message;
        }
        
        return result;
    }

    public double CalculateArea()
    {
        if (_shape.Radius <= 0)
        {
            throw new ArgumentException("Радиус должен быть больше нуля");
        }
        
        return Math.PI * Math.Pow(_shape.Radius, 2);
    }
}