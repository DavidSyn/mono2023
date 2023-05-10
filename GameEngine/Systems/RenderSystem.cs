using GameEngine.Components;
using GameEngine.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Entities.Systems;

namespace GameEngine.Systems
{
    public class RenderSystem : EntityDrawSystem
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly SpriteBatch _spriteBatch;
        private RenderTarget2D _renderTarget;
        private float _scale;
        private FrameCounter _frameCounter;
        private ComponentMapper<PositionComponent> _positionMapper;
        private ComponentMapper<SpriteComponent> _spriteMapper;
        private ComponentMapper<TextComponent> _textMapper;

        public RenderSystem(
            GraphicsDevice graphicsDevice,
            FrameCounter frameCounter)
            : base(Aspect.All(typeof(PositionComponent)).One(typeof(SpriteComponent), typeof(TextComponent)))
        {
            _graphicsDevice = graphicsDevice;
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            _renderTarget = null;
            _scale = 0f;
            _frameCounter = frameCounter;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _positionMapper = mapperService.GetMapper<PositionComponent>();
            _spriteMapper = mapperService.GetMapper<SpriteComponent>();
            _textMapper = mapperService.GetMapper<TextComponent>();

            _renderTarget = new RenderTarget2D(
                _graphicsDevice,
                (int)WindowConstants.WINDOW_WIDTH,
                (int)WindowConstants.WINDOW_HEIGHT);
        }

        public override void Draw(GameTime gameTime)
        {
            _scale = 1f / (WindowConstants.WINDOW_HEIGHT / _graphicsDevice.Viewport.Height);

            _graphicsDevice.SetRenderTarget(_renderTarget);
            _graphicsDevice.Clear(Color.DarkGray);

            var camera = Camera.Instance;
            if (camera.IsEnabled())
            {
                camera.BeginBatchWithTransform(_spriteBatch);
            }
            else
            {
                _spriteBatch.Begin();
            }

            foreach (var entityId in ActiveEntities)
            {
                var position = _positionMapper.Get(entityId);
                if (_spriteMapper.Has(entityId))
                {
                    var sprite = _spriteMapper.Get(entityId);
                    _spriteBatch.Draw(
                        sprite.Texture,
                        position.Position,
                        sprite.DrawColor);
                }
                if (_textMapper.Has(entityId))
                {
                    var text = _textMapper.Get(entityId);
                    _spriteBatch.DrawString(
                        text.Font,
                        text.Text,
                        position.Position,
                        text.TextColor);
                }
            }

            _frameCounter.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            _graphicsDevice.SetRenderTarget(null);
            _graphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
            _spriteBatch.Draw(_renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, _scale, SpriteEffects.None, 0f);
            _spriteBatch.End();
        }
    }
}
