using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Map2D.math.geometry
{
    public class Polygon : GeometricObject
    {
        public List<Point> points;

        public Polygon(List<Point> points)
        {
            this.points = points;
            CreateSides();
        }

        private void CreateSides()
        {
            sides = new Line[points.Count];
            for (int i = 0; i < points.Count; i++)
            {
                sides[i] = new Line(points[i], points[(i + 1) % points.Count]);
            }
        }

        public void Insert(int index, Point point)
        {
            points.Insert(index, point);
            CreateSides();
        }

        public bool Remove(Point point)
        {
            if (!points.Contains(point))
            {
                return false;
            }

            points.Remove(point);
            CreateSides();
            return true;
        }

        public List<Triangle> Triangles()
        {
            List<Triangle> triangles = new List<Triangle>();
            
            Polygon rest = new Polygon(points);

            int i = 0;
            while (rest.points.Count > 0)
            {
                if (i >= rest.points.Count)
                    break;

                Point p1 = i > 0 ? rest.points[i - 1] : rest.points[rest.points.Count - 1];
                Point p = rest.points[i];
                Point p2 = i < rest.points.Count - 1 ? rest.points[i + 1] : rest.points[0];

                Triangle triangle = new Triangle(p1, p, p2);
                
                // Check if triangle is concave
                int l = (p1.X - p.X) * (p2.Y - p.Y) - (p1.Y - p.Y) * (p2.X - p.X);
                if (l > 0) {
                    i++;
                    continue;
                }
                
                // TODO: Support concave polygons

                bool inTriangle = false;
                foreach (Point point in rest.points)
                {
                    if (point == p1 || point == p || point == p2)
                        continue;
                    if (triangle.Contains(point))
                    {
                        inTriangle = true;
                        break;
                    }
                }

                if (inTriangle)
                {
                    i++;
                    continue;
                }
                
                triangles.Add(triangle);
                rest.Remove(rest.points[i]);
                i = 0;
            }

            return triangles;
        }

        public override float Circumference()
        {
            float sum = 0;
            foreach (var line in sides)
            {
                sum += line.Length();
            }

            return sum;
        }

        public override float Area()
        {
            // TODO: Support concave polygons (see Triangles() method)
            
            float sum = 0;
            foreach (Triangle triangle in Triangles())
            {
                sum += triangle.Area();
            }

            return sum;
        }
    }
}