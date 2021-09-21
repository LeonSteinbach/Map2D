using Map2D.graphics.shapes;
using Map2D.math.geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.physics
{
	public class Body
	{
		public Vector2 Position { get; set; }
		public Vector2 Velocity { get; set; }
		public Vector2 Acceleration { get; set; }

		public float Rotation { get; set; }
		public float RotationVelocity { get; set; }
		public float RotationAcceleration { get; set; }

		public bool FixedPosition { get; set; }
		public bool FixedRotation { get; set; }

		public GeometricObject BoundingBox { get; set; }

		public Body()
		{

		}

		public void Update(GameTime gameTime)
		{
			if (!FixedPosition) {
				Velocity += Acceleration * gameTime.ElapsedGameTime.Milliseconds;
				Position += Velocity * gameTime.ElapsedGameTime.Milliseconds;
			}

			if (!FixedRotation) {
				RotationVelocity += RotationAcceleration * gameTime.ElapsedGameTime.Milliseconds;
				Rotation += RotationAcceleration * gameTime.ElapsedGameTime.Milliseconds;
			}
		}

		public void RenderDebug(SpriteBatch spriteBatch, Color color, float thickness)
		{
			Shapes.DrawLines(spriteBatch, BoundingBox, color, thickness);
		}
	}
}