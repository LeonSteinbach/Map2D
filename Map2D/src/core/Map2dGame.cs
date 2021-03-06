using Map2D.assets;
using Map2D.audio;
using Map2D.core.states;
using Map2D.util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.core
{
    public class Map2dGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Map2dGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "res";
        }

        protected override void Initialize()
        {
            Point monitorSize = new Point(
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, 
                GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);

            Point windowSize = new Point(1200, 800);
            
            IsFixedTimeStep = false;
            graphics.SynchronizeWithVerticalRetrace = false;
            
            if (monitorSize == windowSize)
               graphics.IsFullScreen = true;
            
            IsMouseVisible = true;
            Window.AllowUserResizing = false;
            Window.IsBorderless = false;
            Window.Title = "Map2D";
            Window.Position = new Point(
                (int) (monitorSize.X / 2f - windowSize.X / 2f), 
                (int) (monitorSize.Y / 2f - windowSize.Y / 2f));

            graphics.PreferredBackBufferWidth = windowSize.X;
            graphics.PreferredBackBufferHeight = windowSize.Y;
            graphics.ApplyChanges();

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Assets.Initialize(Content);
            AudioManager.Initialize();
            
            StateManager.Start(new MainState());
        }

        protected override void Update(GameTime gameTime)
        {
            StateManager.Update(gameTime);
            TimeHelper.Update((float) gameTime.ElapsedGameTime.TotalSeconds);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
	        GraphicsDevice.Clear(Color.Black);

            StateManager.Render(gameTime, spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}