using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace GameEngine
{
    public class FrameCounter
    {
        private const string FONTNAME = "fonts/consolas";
        private SpriteFont _fpsFont;
        private bool _displayFps;
        private bool _logFrameTimes;

        public void Load(
            ContentManager content,
            bool displayFps,
            bool logFrameTimes)
        {
            _displayFps = displayFps;
            _logFrameTimes = logFrameTimes;

            _fpsFont = content.Load<SpriteFont>(FONTNAME);
            if (_fpsFont == null)
            {
                throw new NullReferenceException($"{FONTNAME}.spritefont could not load.");
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (_displayFps)
            {
                var fps = Math.Round(1 / gameTime.ElapsedGameTime.TotalSeconds, 2);
                if (fps == 60)
                {
                    spriteBatch.DrawString(_fpsFont, "fps:" + fps, new Vector2(3, 3), Color.LightGray);
                }
                else
                {
                    spriteBatch.DrawString(_fpsFont, "fps:" + fps, new Vector2(3, 3), Color.Red);
                }
            }
            if (_logFrameTimes)
            {
                var timePerFrame = gameTime.ElapsedGameTime.TotalMilliseconds;
                Debug.WriteLine($"Frame took {timePerFrame} ms to render.");
            }
        }
    }
}
