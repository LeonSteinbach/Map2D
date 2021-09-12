namespace Map2D.math.geometry
{
    public abstract class GeometricObject
    {
        public Line[] sides;

        public abstract float Circumference();
        public abstract float Area();
    }
}