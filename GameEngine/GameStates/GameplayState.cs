using GameEngine.Input;
using GameEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;

namespace GameEngine.GameStates
{
    public class GameplayState : BaseGameState
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
