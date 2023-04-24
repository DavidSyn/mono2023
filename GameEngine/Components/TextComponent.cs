using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Components
{
    public class TextComponent
    {
        public string Text { get; set; }
        public SpriteFont Font { get; set; }
        public Color TextColor { get; set; }
        public TextComponent(
            string text,
            SpriteFont font,
            Color textColor)
        {
            Text = text;
            Font = font;
            TextColor = textColor;
        }
    }
}
