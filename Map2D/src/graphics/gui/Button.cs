using System;
using Map2D.assets;
using Map2D.audio;
using Map2D.input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.gui
{
	public class Button
	{
		private Texture2D defaultTexture, hoverTexture;
		private string hoverSound, clickSound;
		private string text;
		private SpriteFont font;
		private Color textColor;
		private Rectangle rectangle;
		private int hoverOffset;
		private float hoverScale;
		private float hoverAngle;
		private float layer;

		public Button(Texture2D texture, Vector2 position, bool centered = true, float layer = 1f) :
			this(texture, texture, position, centered, null, null, string.Empty, null, Color.Black, 0, 1f, 0f, layer)
		{

		}

		public Button(Texture2D defaultTexture, Texture2D hoverTexture, Vector2 position, bool centered = true, float layer = 1f) :
			this(defaultTexture, hoverTexture, position, centered, null, null, string.Empty, null, Color.Black, 0, 1f, 0f, layer)
		{
			
		}

		public Button(Texture2D defaultTexture, Texture2D hoverTexture, Vector2 position, bool centered, 
			string hoverSound, string clickSound, string text, SpriteFont font, Color textColor,
			int hoverOffset, float hoverScale, float hoverAngle, float layer = 1f)
		{
			this.defaultTexture = defaultTexture;
			this.hoverTexture = hoverTexture;
			this.hoverSound = hoverSound;
			this.clickSound = clickSound;
			this.text = text;
			this.font = font;
			this.textColor = textColor;
			this.hoverOffset = hoverOffset;
			this.hoverScale = hoverScale;
			this.hoverAngle = hoverAngle;
			this.layer = layer;

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
			bool entered = Hover() && !rectangle.Contains(Input.PreviousMousePosition());
			if (entered)
				AudioManager.PlaySound(hoverSound);
			return entered;
		}

		public bool Left()
		{
			return !Hover() && rectangle.Contains(Input.PreviousMousePosition());
		}

		public bool Pressed()
		{
			bool pressed = Hover() && Input.IsLeftPressed();
			if (pressed)
				AudioManager.PlaySound(clickSound);
			return pressed;
		}

		public void Render(SpriteBatch spriteBatch)
		{
			Texture2D renderTexture = defaultTexture;
			Rectangle renderRectangle = rectangle;
			float renderAngle = hoverAngle;
			float renderScale = hoverScale;

			if (Hover()) {
				renderTexture = hoverTexture;
				renderRectangle.Y += hoverOffset;
			}

			spriteBatch.Draw(renderTexture, renderRectangle.Location.ToVector2(), null, Color.White, 
				hoverAngle, renderRectangle.Center.ToVector2(), renderScale, SpriteEffects.None, layer);

			if (string.IsNullOrEmpty(text) && font != null) {
				Vector2 textPosition = renderRectangle.Center.ToVector2() - FontHelper.TextSize(font, text) / 2f;
				spriteBatch.DrawString(font, text, textPosition, textColor, renderAngle, 
					renderRectangle.Center.ToVector2(), renderScale, SpriteEffects.None, layer);
			}
		}
	}
}
