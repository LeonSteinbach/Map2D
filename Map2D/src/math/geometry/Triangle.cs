using Microsoft.Xna.Framework;

namespace Map2D.math.geometry
{
    public class Triangle : GeometricObject
    {
        public Point a, b, c;

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;

            sides = new Line[3]
            {
                new Line(a, b),
                new Line(b, c),
                new Line(c, a)
            };
        }
        
        public bool Contains(Point point)
        {
            float a1 = ((b.Y - c.Y) * (point.X - c.X) + (c.X - b.X) * (point.Y - c.Y)) / 
                       (float) ((b.Y - c.Y) * (a.X - c.X) + (c.X - b.X) * (a.Y - c.Y));
            float b1 = ((c.Y - a.Y) * (point.Y - c.X) + (a.X - c.X) * (point.Y - c.Y)) / 
                       (float) ((b.Y - c.Y) * (a.X - c.X) + (c.X - b.X) * (a.Y - c.Y));
            float c1 = 1 - a1 - b1;

            return a1 >= 0 && a1 <= 1 && b1 >= 0 && b1<= 1 && c1 >= 0 && c1 <= 1;
        }

        public override float Circumference()
        {
            return sides[0].Length() + sides[1].Length() + sides[2].Length();
        }

        public override float Area()
        {
            return 0.5f * sides[0].Length() * sides[1].Length();
        }
    }
}