namespace Shape_Library.Shapes;

public readonly struct Triangle
{
    public readonly double A;
    public readonly double B;
    public readonly double C;

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override string ToString()
    {
        return $"a:{A}, b:{B}, c:{C}";
    }
}

public class TriangleHandler : IShapeInfo, IShapeAreaHandler
{
    private readonly Triangle _shape;
    
    public TriangleHandler(Triangle shape)
    {
        _shape = shape;
    }
    
    public string GetInfo()
    {
        var result = $"[Треугольник] Стороны - {_shape}, S - ";
        
        try
        {
            var s = CalculateArea();
            result += $"{s:F5}, Тип - {GetTriangleType()}";
        }
        catch (Exception e)
        {
            result += e.Message;
        }
        
        return result;
    }

    public double CalculateArea()
    {
        if (_shape.A <= 0
            || _shape.B <= 0 
            || _shape.C <= 0)
        {
            throw new ArgumentException("Стороны должны быть больше нуля.");
        }
        
        if (_shape.A + _shape.B <= _shape.C 
            || _shape.A + _shape.C <= _shape.B 
            || _shape.B + _shape.C <= _shape.A)
        {
            throw new ArgumentException("Стороны не образуют треугольник.");
        }

        double p = (_shape.A + _shape.B + _shape.C) / 2;
        return Math.Sqrt(p * (p - _shape.A) * (p - _shape.B) * (p - _shape.C));
    }
    
    
    private string GetTriangleType()
    {
        if (Math.Abs(_shape.A - _shape.B) < double.Epsilon 
            && Math.Abs(_shape.B - _shape.C) < double.Epsilon)
        {
            return "Равносторонний";
        }
        
        if (Math.Abs(_shape.A - _shape.B) < double.Epsilon 
            || Math.Abs(_shape.A - _shape.C) < double.Epsilon 
            || Math.Abs(_shape.B - _shape.C) < double.Epsilon)
        {
            return "Равнобедренный";
        }
        
        if (IsRightTriangle())
        {
            return "Прямоугольный";
        }
        
        return "Разносторонний";
    }

    private bool IsRightTriangle()
    {
        double[] sides = { _shape.A, _shape.B, _shape.C };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < double.Epsilon;
    }
}