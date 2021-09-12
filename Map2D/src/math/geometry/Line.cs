using Microsoft.Xna.Framework;

namespace Map2D.math.geometry
{
    public class Line
    {
        public Point a, b;

        public Line(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }
        
        public bool Intersects(Line other) {
            float derivative = (a.X - b.X) * (other.a.Y - other.b.Y) - 
                               (a.Y - b.Y) * (other.a.X - other.b.X);
            float t = ((a.X - other.a.X) * (other.a.Y - other.b.Y) - 
                       (a.Y - other.a.Y) * (other.a.X - other.b.X)) / derivative;
            float u = -((a.X - b.X) * (a.Y - other.a.Y) - 
                        (a.Y - b.Y) * (a.X - other.a.X)) / derivative;

            return t > 0 && t < 1 && u > 0 && u < 1;
        }

        public float Length()
        {
            return MathHelper.Distance(a, b);
        }

        public float Angle()
        {
            return MathHelper.AngleRadians(a, b);
        }
    }
}