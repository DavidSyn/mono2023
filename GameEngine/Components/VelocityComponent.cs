using Microsoft.Xna.Framework;

namespace GameEngine.Components
{
    public class VelocityComponent
    {
        public VelocityComponent(
            float baseSpeed)
        {
            BaseSpeed = baseSpeed;
            Velocity = Vector2.Zero;
        }
        public float BaseSpeed { get; private set; }
        public Vector2 Velocity { get; set; }
        public Vector2 PreviousVelocity { get; set; }
        public float SpeedX { get { return Velocity.X; } set { Velocity = new Vector2(value, Velocity.Y); } }
        public float SpeedY { get { return Velocity.Y; } set { Velocity = new Vector2(Velocity.X, value); } }
    }
}
