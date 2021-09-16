using Map2D.assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.gui
{
	public class Checkbox : Button
	{
		private readonly Texture2D checkedTexture;
		private readonly int margin;
		
		public bool Checked { get; set; }

		private new Texture2D RenderTexture => Checked ? checkedTexture : defaultTexture;

		public Checkbox(bool selected, Texture2D texture, Texture2D checkedTexture,
			Vector2 position, int margin, string text, SpriteFont font, 
			Color color, bool centered = true, float layer = 1f) :
			this(selected, texture, texture, checkedTexture,
				position, margin, text, font, color, centered, layer)
		{

		}

		public Checkbox(bool selected, Texture2D defaultTexture, Texture2D hoverTexture,
			Texture2D checkedTexture, Vector2 position, int margin, string text, 
			SpriteFont font, Color color, bool centered = true, float layer = 1f) :
			this(selected, defaultTexture, hoverTexture, checkedTexture, position, 
				margin, null, null, text, font, color, 0, 1f, 0f, centered, layer)
		{
			
		}

		public Checkbox(bool selected, Texture2D defaultTexture, Texture2D hoverTexture, 
			Texture2D checkedTexture, Vector2 position, int margin, string hoverSound, 
			string clickSound, string text, SpriteFont font, Color color, int hoverOffset,
			float hoverScale, float hoverAngle, bool centered = true, float layer = 1f) :
			base(defaultTexture, hoverTexture, position, centered, hoverSound, 
				clickSound, text, font, color, hoverOffset, hoverScale, hoverAngle, layer)
		{
			this.checkedTexture = checkedTexture;
			this.margin = margin;
			Checked = selected;
		}

		public void Update()
		{
			if (Pressed())
				Checked = !Checked;
		}

		public new void Render(SpriteBatch spriteBatch)
		{
			RenderBase(spriteBatch);

			if (string.IsNullOrEmpty(text) || font == null) return;

			Vector2 textPosition = new Vector2(
				Rectangle.Right + margin, 
				Rectangle.Y + (FontHelper.TextSize(font, text).Y - Rectangle.Height) / 2f);

			spriteBatch.DrawString(font, text, textPosition, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, layer);
		}
	}
}
