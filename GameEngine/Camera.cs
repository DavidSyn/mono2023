using GameEngine.Constants;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public sealed class Camera
    {
        public static Camera Instance { get { return _lazy.Value; } }

        private static readonly Lazy<Camera> _lazy = new Lazy<Camera>(() => new Camera());
        private Matrix _matrix;
        private bool _enabled;

        private Camera()
        {
            _matrix = new Matrix();
        }

        public void Load()
        {
            _matrix = new Matrix();
            _enabled = true;
        }

        public void Unload()
        {
            _matrix = new Matrix();
            _enabled = false;
        }

        public bool IsEnabled()
        {
            return _enabled;
        }

        //public void Follow(PositionComponent position, SpriteComponent sprite)
        //{
        //    var cameraPosition = Matrix.CreateTranslation(
        //            -position.Position.X - (sprite.Texture.Width / 2),
        //            -position.Position.Y - (sprite.Texture.Height / 2),
        //            0);
        //    var cameraOffset = Matrix.CreateTranslation(
        //        WindowConstants.WINDOW_WIDTH / 2,
        //        WindowConstants.WINDOW_HEIGHT / 2,
        //        0);
        //    _matrix = cameraPosition * cameraOffset;
        //}

        public void BeginBatchWithTransform(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: _matrix);
        }
    }
}
