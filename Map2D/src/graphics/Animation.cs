using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics
{
	public class Animation
	{
		private readonly Texture2D texture;
		private readonly int columns;
		private readonly int frameWidth, frameHeight;
		private int currentFrame, frames;
		private int delay;
		private double elapsed;

		public bool Playing { get; private set; }
		public bool Looping { get; set; }
		public bool Flipped { get; set; }

		public Animation(Texture2D texture, int columns, int rows, 
			int frames, int delay, bool looping = true, bool flipped = false)
		{
			this.texture = texture;
			this.columns = columns;
			this.frames = frames;
			this.delay = delay;

			frameWidth = texture.Width / columns;
			frameHeight = texture.Height / rows;
			
			currentFrame = 0;
			elapsed = 0d;

			Looping = looping;
			Flipped = flipped;
		}

		public void Start()
		{
			currentFrame = 0;
			Playing = true;
		}

		public void Resume()
		{
			Playing = true;
		}

		public void Pause()
		{
			Playing = false;
		}

		public void Stop()
		{
			currentFrame = 0;
			Playing = false;
		}

		private Rectangle SourceRectangle => new Rectangle(
			currentFrame % columns * frameWidth, 
			currentFrame / columns, 
			frameWidth, 
			frameHeight);

		public void Render(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position)
		{
			Render(gameTime, spriteBatch, position, 0f, 1f);
		}

		public void Render(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, 
			float rotation, float scale, float layer = 1f)
		{
			Render(gameTime, spriteBatch, position, rotation, new Vector2(scale), layer);
		}

		public void Render(GameTime gameTime, SpriteBatch spriteBatch, Vector2 position, 
			float rotation, Vector2 scale, float layer = 1f)
		{
			if (!Playing)
				return;

			SpriteEffects effect = Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

			spriteBatch.Draw(texture, position, SourceRectangle, Color.White, 
				rotation, Vector2.Zero, scale, effect, layer);

			elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;
			if (elapsed >= delay) {
				if (currentFrame >= frames - 1) {
					if (Looping)
						currentFrame = 0;
					else
						Stop();
				} else {
					currentFrame++;
				}

				elapsed = 0d;
			}
		}
	}
}