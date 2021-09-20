using Map2D.math.geometry;
using Microsoft.Xna.Framework;

namespace Map2D.physics
{
	public abstract class Body
	{
		public Vector2 Position { get; set; }
		public Vector2 Velocity { get; set; }
		public Vector2 Acceleration { get; set; }
		public Vector2 Rotation { get; set; }
		public GeometricObject BoundingBox { get; set; }

		// TODO: Update, RenderBoundingBox (debug), forces, center of mass (in math)
		// TODO: Add body types (static, dynamic, rotatable)
		// TODO: Add world structure (list of bodies)
	}
}