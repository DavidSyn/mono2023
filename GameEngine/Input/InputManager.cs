using GameEngine.Extensions;
using GameEngine.Input.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameEngine.Input
{
    public class InputManager
    {
        public IList<InputCommand> PastInputCommands { get; private set; }

        private PlayerIndex? _gamePadPortUsed;
        private bool _gamePadConnected;  

        public InputManager() 
        {
            _gamePadConnected = false;
            _gamePadPortUsed = null;
        }

        public IList<InputCommand> GetInputState()
        {
            var result = new List<InputCommand>();
            CheckGamepadPort();

            result.AddRange(AddGamePadInput());
            result.AddRange(AddKeyboardInput());

            result.DistinctAndClean();
            PastInputCommands = result;
            return result;
        }

        private IEnumerable<InputCommand> AddKeyboardInput()
        {
            var result = new List<InputCommand>();

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {
                result.Add(new Right());
            }
            if (state.IsKeyDown(Keys.Left))
            {
                result.Add(new Left());
            }

            return result;
        }

        private IList<InputCommand> AddGamePadInput()
        {
            var result = new List<InputCommand>();

            if (_gamePadConnected && _gamePadPortUsed.HasValue)
            {
                GamePadCapabilities capabilities = GamePad.GetCapabilities(_gamePadPortUsed.Value);
                GamePadState state = GamePad.GetState(_gamePadPortUsed.Value);

                if (state.LeftStickHoldingRight(capabilities))
                {
                    result.Add(new Right());
                }
                if (state.LeftStickHoldingLeft(capabilities))
                {
                    result.Add(new Left());
                }
            }

            return result;
        }

        private void CheckGamepadPort()
        {
            _gamePadPortUsed = null;
            _gamePadConnected = false;
            if (GamePad.GetCapabilities(PlayerIndex.One).IsConnected)
            {
                _gamePadPortUsed = PlayerIndex.One;
                _gamePadConnected = true;
            }
            else if (GamePad.GetCapabilities(PlayerIndex.Two).IsConnected)
            {
                _gamePadPortUsed = PlayerIndex.Two;
                _gamePadConnected = true;
            }
            else if (GamePad.GetCapabilities(PlayerIndex.Three).IsConnected)
            {
                _gamePadPortUsed = PlayerIndex.Three;
                _gamePadConnected = true;
            }
            else if (GamePad.GetCapabilities(PlayerIndex.Four).IsConnected)
            {
                _gamePadPortUsed = PlayerIndex.Four;
                _gamePadConnected = true;
            }
        }
    }
}
