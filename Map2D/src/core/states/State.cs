using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.core.states
{
	public abstract class State
	{
		public State lastState;
		public bool running;

		protected State()
		{
			lastState = null;
			running = false;
		}

		protected State(State lastState)
		{
			this.lastState = lastState;
			running = false;
		}

		public abstract void Initialize();
		public abstract void LoadContent();
		public abstract void Dispose();
		public abstract void Update(GameTime gameTime);
		public abstract void Render(GameTime gameTime, SpriteBatch spriteBatch);

		public void Start()
		{
			running = true;
			Initialize();
			LoadContent();
		}

		public void Resume()
		{
			running = true;
		}

		public void Pause()
		{
			running = false;
		}

		public void Stop()
		{
			Pause();
			Dispose();

			lastState?.Resume();
		}
	}
}
