using Shape_Library;
using Shape_Library.Shapes;


var shapeHandlers = new List<IShapeInfo>()
{
    new CircleHandler(new Circle(1)),
    new CircleHandler(new Circle(2)),
    new CircleHandler(new Circle(0)),
    new TriangleHandler(new Triangle(5,3,4)),
    new TriangleHandler(new Triangle(6,6,6)),
    new TriangleHandler(new Triangle(5,5,8)),
    new TriangleHandler(new Triangle(1,2,3)),
};

foreach (var handler in shapeHandlers)
{
    Console.WriteLine(handler.GetInfo());
}

