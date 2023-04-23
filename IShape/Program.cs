using System;

public interface IShape
{
    public double CalculateArea();
    public double CalculatePerimeter();
}

public class Square : IShape
{
    public double Side { get; set; }
    private double _side;
    private double _area;
    private double _perimeter;
    public void ValidateSide()
    {
        _side = Side;
        if (_side <= 0) { throw new ArgumentException(); }
    }
    public double CalculateArea()
    {
        ValidateSide();
        _area = _side * _side;
        return _area;
    }
    public double CalculatePerimeter()
    {
        ValidateSide();
        _perimeter = _side * 4;
        return _perimeter;
    }
}

public class Triangle : IShape 
{
    public double FirstSide { get; set; }
    public double SecondSide { get; set; }
    public double ThirdSide { get; set; }
    private double _firstSide;
    private double _secondSide;
    private double _thirdSide;
    private double _area;
    private double _perimeter;
    private double halfPerimeter;

    public void ValidateSides()
    {
        _firstSide = FirstSide;
        _secondSide = SecondSide;
        _thirdSide = ThirdSide;
        if ((_firstSide <= 0) || (_secondSide <= 0) || (_thirdSide <= 0)) { throw new ArgumentException(); }
    }


    public double CalculateArea()
    {
        ValidateSides();
        halfPerimeter = (_firstSide + _secondSide + _thirdSide) / 2;
        _area = Math.Sqrt(halfPerimeter * (halfPerimeter - _firstSide) * (halfPerimeter - _secondSide) * (halfPerimeter - _thirdSide));
        return _area;
    }
    public double CalculatePerimeter()
    {
        ValidateSides();
        _perimeter = _firstSide + _secondSide + _thirdSide; 
        return _perimeter;
    }
}

public class Circle : IShape 
{
    public double Radius { get; set; }
    private double _radius;
    private double _area;
    private double _perimeter;
    public void ValidateRadius()
    {
        _radius = Radius;
        if (_radius <= 0) { throw new ArgumentException(); }
    }
    public double CalculateArea()
    {
        ValidateRadius();
        _area = double.Pi * _radius * _radius;
        return _area;
    }
    public double CalculatePerimeter()
    {
        ValidateRadius();
        _perimeter = 2 * double.Pi * _radius;
        return _perimeter;
    }
}

class Program
{
    static void Main()
    {
        var square = new Square()
        {
            Side = 5
        };
        Console.WriteLine($"Площадь квадрата со стороной {square.Side} = {square.CalculateArea()}");
        Console.WriteLine($"Периметр квадрата со стороной {square.Side} = {square.CalculatePerimeter()}");

        var triangle = new Triangle()
        {
            FirstSide = 3,
            SecondSide = 4,
            ThirdSide = 5
            
        };
        Console.WriteLine($"Площадь треугольника со сторонами {triangle.FirstSide}, {triangle.SecondSide}, {triangle.ThirdSide}, = {triangle.CalculateArea()}");
        Console.WriteLine($"Периметр треугольника со сторонами {triangle.FirstSide}, {triangle.SecondSide}, {triangle.ThirdSide}, = {triangle.CalculatePerimeter()}");

        var circle = new Circle()
        {
            Radius = 1
        };
        Console.WriteLine($"Площадь круга с радиусом {circle.Radius} = {circle.CalculateArea()}");
        Console.WriteLine($"Периметр круга с радиусом {circle.Radius} = {circle.CalculatePerimeter()}");



    }
}