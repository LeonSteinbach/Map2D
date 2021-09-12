using Microsoft.Xna.Framework;

namespace Map2D.math.geometry
{
    public class Rectangle : GeometricObject
    {
        public Point topLeft, topRight, bottomLeft, bottomRight;
        public int top, bottom, left, right;
        public int width, height;

        public Rectangle(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
            
            top = topLeft.Y;
            bottom = top + height;
            left = topLeft.X;
            right = left + width;
            
            topLeft = new Point(left, top);
            topRight = new Point(right, top);
            bottomLeft = new Point(left, bottom);
            bottomRight = new Point(right, bottom);

            sides = new Line[4]
            {
                new Line(topLeft, topRight),
                new Line(topRight, bottomRight),
                new Line(bottomRight, bottomLeft),
                new Line(bottomLeft, topLeft)
            };
        }

        public bool Contains(Point point)
        {
            return !(point.X < left || point.X > right || point.Y < top || point.Y > bottom);
        }

        public bool Intersects(Rectangle other)
        {
            return !(other.right < left || other.left > right || other.bottom < top || other.top > bottom);
        }

        public override float Circumference()
        {
            return 2 * width + 2 * height;
        }

        public override float Area()
        {
            return width * height;
        }
    }
}