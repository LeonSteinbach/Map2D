using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.gui
{
	public class RadioButton : Checkbox
	{
		private RadioGroup radioGroup;

		public RadioButton(RadioGroup radioGroup, bool selected, Texture2D texture, 
			Texture2D checkedTexture, Vector2 position, int margin, string text, 
			SpriteFont font, Color color, bool centered = true, float layer = 1) :
			this(radioGroup, selected, texture, texture, checkedTexture, position,
				margin, null, null, text, font, color, 0, 1f, 0f, centered, layer)
		{

		}

		public RadioButton(RadioGroup radioGroup, bool selected, Texture2D defaultTexture, 
			Texture2D hoverTexture, Texture2D checkedTexture, Vector2 position, int margin, 
			string text, SpriteFont font, Color color, bool centered = true, float layer = 1) :
			this(radioGroup, selected, defaultTexture, hoverTexture, checkedTexture, position,
				margin, null, null, text, font, color, 0, 1f, 0f, centered, layer)
		{

		}

		public RadioButton(RadioGroup radioGroup, bool selected, Texture2D defaultTexture, 
			Texture2D hoverTexture, Texture2D checkedTexture, Vector2 position, int margin, 
			string hoverSound, string clickSound, string text, SpriteFont font, Color color, 
			int hoverOffset, float hoverScale, float hoverAngle, bool centered = true, float layer = 1) :
			base(selected, defaultTexture, hoverTexture, checkedTexture, position,
				margin, hoverSound, clickSound, text, font, color,
				hoverOffset, hoverScale, hoverAngle, centered, layer)
		{
			this.radioGroup = radioGroup;
		}

		public new void Update()
		{
			if (Pressed() && !Checked) {
				foreach (RadioButton other in radioGroup.Buttons)
					other.Checked = false;
				Checked = true;
			}
		}
	}
}