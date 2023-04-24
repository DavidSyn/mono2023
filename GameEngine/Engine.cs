using GameEngine.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameEngine
{
    public class Engine : Game
    {
        private GraphicsDeviceManager _graphics;

        public Engine()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Window.Title = "monogame2023";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            TargetElapsedTime = TimeSpan.FromTicks((long)(TimeSpan.TicksPerSecond / 60f));

            _graphics.PreferredBackBufferWidth = (int)WindowConstants.WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = (int)WindowConstants.WINDOW_HEIGHT;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}