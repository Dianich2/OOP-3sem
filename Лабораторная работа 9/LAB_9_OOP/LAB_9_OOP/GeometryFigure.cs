using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_9_OOP
{
    internal class GeometryFigure
    {
        public string? TypeD { get; set; }
        public string? Name { get; set; }

        public List<int>? Sides;
        public double? Radius { get; set; }

        public GeometryFigure()
        {
            TypeD = "2D";
            Name = "Треугольник";
            Sides = new List<int>() { 3, 4, 5};
            Radius = null;
        }
        public GeometryFigure(string t, string n, List<int>? side = null, double? radius = null)
        {
            TypeD = t;
            Name = n;
            Sides = side;
            Radius = radius;
        }

        public void PrintInformationAboutFigure()
        {
            Console.Write($"Тип: {this.TypeD}, название: {this.Name} ");
            if(this.Sides != null)
            {
                Console.Write("стороны: ");
                foreach (int i in this.Sides) { 
                    Console.Write($"{i}, ");
                }
            }
            if (this.Radius != null)
            {
                Console.Write($"радиус: {this.Radius}");
            }
            Console.WriteLine();
        }

        public override bool Equals(object? obj)
        {
            GeometryFigure other = obj as GeometryFigure;
            if(other.TypeD == this.TypeD && other.Sides == this.Sides && other.Name == this.Name && other.Radius == this.Radius)
            {
                return true;
            }
            return false;
        }

    }
}
