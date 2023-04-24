using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using MonoGame.Extended.Entities;
using GameEngine.Input;
using GameEngine.Constants;

namespace GameEngine.GameStates
{
    public abstract class BaseGameState
    {
        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<EventTypeEnum> OnEventNotification;
        protected ContentManager _contentManager;
        protected InputManager _inputManager;
        protected GraphicsDevice _graphicsDevice;
        protected FrameCounter _frameCounter;
        protected World _entities;

        public abstract void Initialize(ContentManager contentManager, GraphicsDevice graphicsDevice);
        public abstract void LoadContent();
        public abstract void UnloadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

        protected Texture2D LoadTexture(string textureUrl)
        {
            var texture = _contentManager.Load<Texture2D>(textureUrl);
            return (texture is null) ?
                throw new NullReferenceException($"Could not load texture with name: {textureUrl}") :
                texture;
        }

        protected SpriteFont LoadFont(string fontUrl)
        {
            var font = _contentManager.Load<SpriteFont>(fontUrl);
            return (font is null) ?
                throw new NullReferenceException($"Could not load texture with name: {fontUrl}") :
                font;
        }

        protected void LoadFPSCounter()
        {
            _frameCounter.Load(_contentManager, true, false);
        }

        protected void SwitchState(BaseGameState gameState, object args = null)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        protected void NotifyEvent(EventTypeEnum eventType, object args = null)
        {
            OnEventNotification?.Invoke(this, eventType);
        }

        protected void CheckInitialization()
        {
            if (_entities is null)
            {
                throw new NullReferenceException("World is not initialized.");
            }
        }
    }
}
