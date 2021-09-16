using Map2D.assets;
using Map2D.audio;
using Map2D.input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.gui
{
	public class Button
	{
		protected Texture2D defaultTexture, hoverTexture;
		protected string hoverSound, clickSound;
		protected Rectangle rectangle;
		protected int hoverOffset;
		protected float hoverScale;
		protected float hoverAngle;
		protected float layer;

		protected readonly string text;
		protected readonly SpriteFont font;
		protected readonly Color color;

		protected int RenderOffset => Hover() ? hoverOffset : 0;
		protected float RenderScale => Hover() ? hoverScale : 1f;
		protected float RenderAngle => Hover() ? hoverAngle : 0f;
		protected Texture2D RenderTexture => Hover() ? hoverTexture : defaultTexture;
		protected Rectangle RenderRectangle => Hover() ? rectangle :
			new Rectangle(rectangle.X, rectangle.Y + hoverOffset, rectangle.Width, rectangle.Height);

		public Rectangle Rectangle => rectangle;

		public Button(Texture2D texture, Vector2 position, 
			bool centered = true, float layer = 1f) :
			this(texture, texture, position, centered, null, null, 
				string.Empty, null, Color.Black, 0, 1f, 0f, layer)
		{

		}

		public Button(Texture2D defaultTexture, Texture2D hoverTexture, 
			Vector2 position, bool centered = true, float layer = 1f) :
			this(defaultTexture, hoverTexture, position, centered, null, null, 
				string.Empty, null, Color.Black, 0, 1f, 0f, layer)
		{
			
		}

		public Button(Texture2D defaultTexture, Texture2D hoverTexture, 
			Vector2 position, bool centered, string hoverSound, string clickSound, 
			string text, SpriteFont font, Color color, int hoverOffset, 
			float hoverScale, float hoverAngle, float layer = 1f)
		{
			this.defaultTexture = defaultTexture;
			this.hoverTexture = hoverTexture;
			this.hoverSound = hoverSound;
			this.clickSound = clickSound;
			this.hoverOffset = hoverOffset;
			this.hoverScale = hoverScale;
			this.hoverAngle = hoverAngle;
			this.layer = layer;
			this.text = text;
			this.font = font;
			this.color = color;

			if (centered) {
				position.X -= defaultTexture.Width / 2f;
				position.Y -= defaultTexture.Height / 2f;
			}

			rectangle = new Rectangle((int)position.X, (int)position.Y,
				defaultTexture.Width, defaultTexture.Height);
		}

		public bool Hover()
		{
			return rectangle.Contains(Input.MousePosition());
		}

		public bool Entered()
		{
			return Hover() && !rectangle.Contains(Input.PreviousMousePosition());
		}

		public bool Left()
		{
			return !Hover() && rectangle.Contains(Input.PreviousMousePosition());
		}

		public bool Pressed()
		{
			return Hover() && Input.IsLeftPressed();
		}

		public void UpdateSounds()
		{
			if (Entered())
				AudioManager.PlaySound(hoverSound);
			if (Pressed())
				AudioManager.PlaySound(clickSound);
		}

		protected void RenderBase(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(RenderTexture, RenderRectangle.Location.ToVector2() + new Vector2(0, RenderOffset), null, Color.White,
				RenderAngle, RenderRectangle.Center.ToVector2(), RenderScale, SpriteEffects.None, layer);
		}

		public void Render(SpriteBatch spriteBatch)
		{
			RenderBase(spriteBatch);

			if (string.IsNullOrEmpty(text) || font == null) return;
			Vector2 textPosition = RenderRectangle.Center.ToVector2() + new Vector2(0, RenderOffset) - FontHelper.TextSize(font, text) / 2f;
			spriteBatch.DrawString(font, text, textPosition, color, RenderAngle, 
				RenderRectangle.Center.ToVector2(), RenderScale, SpriteEffects.None, layer);
		}
	}
}
