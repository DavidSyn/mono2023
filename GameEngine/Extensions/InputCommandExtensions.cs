using GameEngine.Input.Commands;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Extensions
{
    public static class InputCommandExtensions
    {
        public static IList<InputCommand> DistinctAndClean(this List<InputCommand> inputs)
        {
            inputs.Distinct();
            if (inputs.Any(x => x is Left) && inputs.Any(x => x is Right))
            {
                inputs.RemoveAll(x => x is Right);
                inputs.RemoveAll(x => x is Left);
            }

            return inputs;
        }
    }
}
