using System;
using Microsoft.Xna.Framework;

namespace Map2D.math.geometry
{
    public class Circle : GeometricObject
    {
        public Point[] points;
        public Point center;
        public float radius;
        public int numSides;

        public Circle(Point center, float radius, int numSides)
        {
            this.center = center;
            this.radius = radius;
            this.numSides = numSides;

            const double max = 2.0 * Math.PI;
            double step =  max / numSides;

            points = new Point[numSides];
            sides = new Line[numSides];
            
            for (int i = 0; i < numSides; i++)
            {
                double theta = i * step;
                points[i] = new Point((int) (radius * Math.Cos(theta)), (int) (radius * Math.Sin(theta))) + center;

                if (i > 0)
                    sides[i] = new Line(points[i - 1], points[i]);
            }
            sides[0] = new Line(points[numSides - 1], points[0]);
        }

        public override float Circumference()
        {
            return 2 * (float) Math.PI * radius;
        }

        public override float Area()
        {
            return (float) Math.PI * radius * radius;
        }
    }
}