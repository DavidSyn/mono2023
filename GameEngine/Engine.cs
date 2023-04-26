using GameEngine.Constants;
using GameEngine.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameEngine
{
    public class Engine : Game
    {
        private GraphicsDeviceManager _graphics;
        private BaseGameState _currentState;

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
            SwitchGameState(new SplashGameState());
        }

        protected override void UnloadContent()
        {
            _currentState?.UnloadContent();
            base.UnloadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                UnloadContent();
                Exit();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (_currentState is SplashGameState)
                {
                    SwitchGameState(new GameplayState());
                }
            }

            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _currentState.Draw(gameTime);
            base.Draw(gameTime);
        }

        private void CurrentState_OnStateSwitched(object sender, BaseGameState e)
        {
            SwitchGameState(e);
        }

        private void CurrentState_OnEventNotification(object sender, EventTypeEnum e)
        {
            switch (e)
            {
                case EventTypeEnum.GAME_QUIT:
                    Exit();
                    break;
            }
        }

        private void SwitchGameState(BaseGameState state)
        {
            if (_currentState != null)
            {
                _currentState.OnStateSwitched -= CurrentState_OnStateSwitched;
                _currentState.OnEventNotification -= CurrentState_OnEventNotification;
                _currentState.UnloadContent();
            }

            _currentState = state;

            _currentState.Initialize(Content, GraphicsDevice);
            _currentState.LoadContent();

            _currentState.OnStateSwitched += CurrentState_OnStateSwitched;
            _currentState.OnEventNotification += CurrentState_OnEventNotification;
        }
    }
}