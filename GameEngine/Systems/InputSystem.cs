using GameEngine.Components;
using GameEngine.Input.Commands;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Entities.Systems;
using MonoGame.Extended.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Systems
{
    public class InputSystem : EntityUpdateSystem
    {
        private readonly InputManager _inputManager;
        private ComponentMapper<VelocityComponent> _velocityMapper;

        public InputSystem(InputManager inputManager)
            : base(Aspect.All(typeof(PlayerComponent), typeof(VelocityComponent)))
        {
            _inputManager = inputManager;
        }

        public override void Initialize(IComponentMapperService mapperService)
        {
            _velocityMapper = mapperService.GetMapper<VelocityComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            var deltaTime = (float)gameTime.ElapsedGameTime.Ticks / TimeSpan.TicksPerSecond;
            IList<InputCommand> inputs = _inputManager.GetInputState();

            if (inputs.Count > 0)
            {
                foreach (var entityId in ActiveEntities)
                {
                    foreach (var input in inputs)
                    {
                        if (input is Right)
                        {
                            var velocity = _velocityMapper.Get(entityId);
                            velocity.SpeedX = (int)Math.Round(velocity.BaseSpeed * deltaTime);
                        }
                        if (input is Left)
                        {
                            var velocity = _velocityMapper.Get(entityId);
                            velocity.SpeedX = (int)Math.Round(-velocity.BaseSpeed * deltaTime);
                        }
                    }
                }
            }
        }
    }
}
