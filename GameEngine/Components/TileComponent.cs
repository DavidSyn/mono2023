using GameEngine.Constants;

namespace GameEngine.Components
{
    public class TileComponent
    {
        public TileTypeEnum TileType { get; set; }
        
        public TileComponent(TileTypeEnum type)
        {
            TileType = type;
        }
    }
}
