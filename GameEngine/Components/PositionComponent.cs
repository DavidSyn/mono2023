using Microsoft.Xna.Framework;

namespace GameEngine.Components
{
    public class PositionComponent
    {
        public Vector2 Position { get; set; }
        public PositionComponent(float x, float y)
        {
            Position = new Vector2(x, y);
        }
    }
}
