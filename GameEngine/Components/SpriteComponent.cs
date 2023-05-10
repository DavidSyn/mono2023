using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameEngine.Constants;

namespace GameEngine.Components
{
    public class SpriteComponent
    {
        public Texture2D Texture { get; set; }
        public Color DrawColor { get; set; }
        public bool Draw { get; set; }
        public LayerEnum Layer { get; set; }

        public SpriteComponent(
            Texture2D texture,
            LayerEnum layer = LayerEnum.Normal,
            bool draw = true)
        {
            Texture = texture;
            DrawColor = Color.White;
            Layer = layer;
            Draw = draw;
        }

        public Matrix GetTransform(Vector2 position, float rotation = 0f)
        {
            var origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            var originPostion = new Vector2(
                position.X + (Texture.Width / 2),
                position.Y + (Texture.Height / 2));

            return Matrix.CreateTranslation(new Vector3(-origin, 0)) *
                  Matrix.CreateRotationZ(rotation) *
                  Matrix.CreateTranslation(new Vector3(originPostion, 0));
        }

        public Color[] GetColorData()
        {
            var result = new Color[Texture.Width * Texture.Height];
            Texture.GetData(result);
            return result;
        }
    }
}
