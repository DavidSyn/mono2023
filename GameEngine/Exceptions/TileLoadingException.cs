using System;

namespace GameEngine.Exceptions
{
    public class TileLoadingException : Exception
    {
        public TileLoadingException(
            string levelName,
            int lineNumber)
            : base($"While loading level {levelName}: The length of line {lineNumber} is different from all preceeding lines.") { }
    }
}
