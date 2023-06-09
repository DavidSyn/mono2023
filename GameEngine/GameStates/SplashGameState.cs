﻿using GameEngine.Components;
using GameEngine.Input;
using GameEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;

namespace GameEngine.GameStates
{
    public class SplashGameState : BaseGameState
    {

        public override void Initialize(
            ContentManager contentManager, 
            GraphicsDevice graphicsDevice)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _inputManager = new InputManager();
            _frameCounter = new FrameCounter();

            _entities = new WorldBuilder()
                .AddSystem(new RenderSystem(_graphicsDevice, _frameCounter))
                .Build();
        }

        public override void LoadContent()
        {
            LoadFPSCounter();

            var titleFont = LoadFont("Fonts/consolas_title");
            var subtitleFont = LoadFont("Fonts/consolas_subtitle");

            var title = _entities.CreateEntity();
            title.Attach(new TextComponent("coolgamename", titleFont, Color.Black));
            title.Attach(new PositionComponent(803, 440));

            var subtitle = _entities.CreateEntity();
            subtitle.Attach(new TextComponent("press Enter or Start", subtitleFont, Color.Black));
            subtitle.Attach(new PositionComponent(803, 500));
        }

        public override void UnloadContent()
        {
            _contentManager.Unload();
        }

        public override void Draw(GameTime gameTime)
        {
            _entities.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _entities.Update(gameTime);
        }
    }
}
