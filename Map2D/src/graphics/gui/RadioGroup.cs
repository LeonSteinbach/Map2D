using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.gui
{
	public class RadioGroup
	{
		public RadioGroup()
		{
			Buttons = new List<RadioButton>();
		}

		public RadioGroup(List<RadioButton> buttons)
		{
			Buttons = buttons;
		}

		public List<RadioButton> Buttons { get; set; }

		public RadioButton Checked
		{
			get {
				foreach (RadioButton button in Buttons) {
					if (button.Checked)
						return button;
				}

				return null;
			}
		}

		public int CheckedIndex
		{
			get {
				for (int i = 0; i < Buttons.Count; i++) {
					if (Buttons[i].Checked)
						return i;
				}

				return -1;
			}
			set {
				foreach (RadioButton button in Buttons)
					button.Checked = false;
				Buttons[value].Checked = true;
			}
		}

		public void Update()
		{
			foreach (RadioButton button in Buttons)
				button.Update();
		}

		public void UpdateSounds()
		{
			foreach (RadioButton button in Buttons)
				button.UpdateSounds();
		}

		public void Render(SpriteBatch spriteBatch)
		{
			foreach (RadioButton button in Buttons)
				button.Render(spriteBatch);
		}
	}
}