using System;

namespace FigureSettings
{
    public abstract class FigureFabric
    {
        public abstract double GetFigureArea();
        //protected abstract bool IsValidInput(params double[] inputs);

        //Думал реализовать этот метод, однако в таком случае есть возможность ввести несколько значений радиусов для окружности,
        //что повлечет за собой необходимость проверки количества аргументов.
        //Все же лучше для каждой фигуры реализовать индивидуальные проверки валидности,
        //так как программист в "подсказках" среды разработки будет видеть, какие именно агрументы от него ждут 

        //В то же время, если реализовать без параметров, то нам придется выделять память под потенциально некорректные значения.
        //Exception прервет выполнение кода, но в этом случае будет излишнее потребление ресурсов, хоть и кратковременное. 
        //Если параметром указать objec, то у нас не будет жесткого ограничения на количество аргументов, так как пользователь может ввести массив, список и тд
    }

    public class Triangle : FigureFabric
    {
        private readonly double[] sides;

        public Triangle(double a, double b, double c)
        {
            if (!ArePositiveSides(a, b, c)) throw new ArgumentException("Стороны треугольна должны быть строго больше нуля.");

            if (!AreValidSides(a, b, c)) throw new ArgumentException("Чтобы треугольник существовал, сумма двух сторон треугольника всегда должна быть больше третей стороны.");

            this.sides = new double[] { a, b, c };
        }

        public override double GetFigureArea()
        {
            double perimetr = 0;
            foreach (var side in this.sides)
            {
                perimetr += side / 2;
            }

            return Math.Sqrt(perimetr * (perimetr - this.sides[0]) * (perimetr - this.sides[1]) * (perimetr - this.sides[2]));
        }

        private bool ArePositiveSides(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0;
        }

        private bool AreValidSides(double a, double b, double c)
        {
            return (a + b > c) && (b + c > a) && (c + a > b);
        }

        public bool IsRigthTriangle()
        {
            return (sides[0] * sides[0] + sides[1] * sides[1] == sides[2] * sides[2]) ||
                (sides[2] * sides[2] + sides[1] * sides[1] == sides[0] * sides[0]) ||
                (sides[0] * sides[0] + sides[2] * sides[2] == sides[1] * sides[1]);
        }
    }

    public class Circle : FigureFabric
    {
        private readonly double radius;

        public Circle(double radius)
        {
            if (!IsValidRadius(radius)) throw new ArgumentException("Длина радиуса должна быть положительной");
            this.radius = radius;
        }

        private bool IsValidRadius(double radius)
        {
            return radius > 0;
        }

        public override double GetFigureArea()
        {
            return Math.PI * radius * radius;
        }
    }
}