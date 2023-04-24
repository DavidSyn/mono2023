using Microsoft.Xna.Framework.Input;

namespace GameEngine.Extensions
{
    public static class GamePadStateExtensions
    {
        public static bool LeftStickHoldingLeft(this GamePadState state, GamePadCapabilities capabilities)
        {
            if (capabilities.HasLeftXThumbStick)
            {
                if (state.ThumbSticks.Left.X < -0.4f)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool LeftStickHoldingRight(this GamePadState state, GamePadCapabilities capabilities)
        {
            if (capabilities.HasLeftXThumbStick)
            {
                if (state.ThumbSticks.Left.X > 0.4f)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool LeftStickHoldingDown(this GamePadState state, GamePadCapabilities capabilities)
        {
            if (capabilities.HasLeftYThumbStick)
            {
                if (state.ThumbSticks.Left.Y < -0.4F)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool LeftStickHoldingUp(this GamePadState state, GamePadCapabilities capabilities)
        {
            if (capabilities.HasLeftYThumbStick)
            {
                if (state.ThumbSticks.Left.Y > 0.4F)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool PressedA(this GamePadState state, GamePadCapabilities capabilities)
        {
            if (state.Buttons.A == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public static bool PressedB(this GamePadState state, GamePadCapabilities capabilities)
        {
            if (state.Buttons.B == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
    }
}
