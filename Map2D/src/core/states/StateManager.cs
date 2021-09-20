using Map2D.input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.core.states
{
	public static class StateManager
	{
		private static State currentState;

		public static void Start(State state)
		{
			State temp = currentState;
			currentState = state;
			currentState.lastState = temp;

			currentState.Start();
		}

		public static void Resume()
		{
			currentState.Resume();
		}

		public static void Pause()
		{
			currentState.Pause();
		}

		public static void Stop()
		{
			currentState.Stop();
		}

		public static void Update(GameTime gameTime)
		{
			currentState.Update(gameTime);
			Input.Update();
		}

		public static void Render(GameTime gameTime, SpriteBatch spriteBatch)
		{
			currentState.Render(gameTime, spriteBatch);
		}
	}
}
