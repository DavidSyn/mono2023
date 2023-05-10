using GameEngine.Components;
using GameEngine.Constants;
using GameEngine.Exceptions;
using GameEngine.Input;
using GameEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Entities;
using System.Collections.Generic;
using System.IO;

namespace GameEngine.GameStates
{
    public class GameplayState : BaseGameState
    {
        private bool RENDER_TILES = true;
        private LayerEnum TILES_LAYER_LEVEL = LayerEnum.Background;

        public override void Initialize(
            ContentManager contentManager, 
            GraphicsDevice graphicsDevice)
        {
            _contentManager = contentManager;
            _graphicsDevice = graphicsDevice;
            _inputManager = new InputManager();
            _frameCounter = new FrameCounter();

            _entities = new WorldBuilder()
                .AddSystem(new RenderSystem(_graphicsDevice, _frameCounter))
                .Build();
        }

        public override void LoadContent()
        {
            LoadFPSCounter();
            LoadTiles("01");
        }

        public override void UnloadContent()
        {
            var camera = Camera.Instance;
            camera.Unload();
            _contentManager.Unload();
        }

        public override void Draw(GameTime gameTime)
        {
            _entities.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _entities.Update(gameTime);
        }

        private void LoadTiles(
            string levelName)
        {
            var routePrefix = "sprites/blocks/";
            var emptyTile = LoadTexture($"{routePrefix}tile");
            var blockingTile = LoadTexture($"{routePrefix}blocking_tile");
            var blockingTileLeftSlope = LoadTexture($"{routePrefix}blocking_tile_left_slope");
            var blockingTileRightSlope = LoadTexture($"{routePrefix}blocking_tile_right_slope");

            string path = $"Content/levels/{levelName}.txt";
            using (Stream fileStream = TitleContainer.OpenStream(path))
            {
                int width = 0;
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadLine();
                    width = line.Length;
                    while (line != null)
                    {
                        lines.Add(line);
                        if (line.Length != width)
                            throw new TileLoadingException(levelName, lines.Count);
                        line = reader.ReadLine();
                    }
                }

                var y = 0;
                foreach (string line in lines)
                {
                    var x = 0;
                    foreach (char c in line)
                    {
                        var tile = _entities.CreateEntity();
                        tile.Attach(new PositionComponent(x, y));
                        switch (c)
                        {
                            case '_':
                                tile.Attach(new SpriteComponent(
                                    emptyTile,
                                    TILES_LAYER_LEVEL,
                                    RENDER_TILES));
                                tile.Attach(new TileComponent(
                                    TileTypeEnum.Empty));
                                break;
                            case '#':
                                tile.Attach(new SpriteComponent(
                                    blockingTile,
                                    TILES_LAYER_LEVEL,
                                    RENDER_TILES));
                                tile.Attach(new TileComponent(
                                    TileTypeEnum.Block));
                                break;
                            case '/':
                                tile.Attach(new SpriteComponent(
                                    blockingTileRightSlope,
                                    TILES_LAYER_LEVEL,
                                    RENDER_TILES));
                                tile.Attach(new TileComponent(
                                    TileTypeEnum.Slope));
                                break;
                            case '\\':
                                tile.Attach(new SpriteComponent(
                                    blockingTileLeftSlope,
                                    TILES_LAYER_LEVEL,
                                    RENDER_TILES));
                                tile.Attach(new TileComponent(
                                    TileTypeEnum.Slope));
                                break;
                            default:
                                tile.Attach(new SpriteComponent(
                                    emptyTile,
                                    TILES_LAYER_LEVEL,
                                    RENDER_TILES));
                                tile.Attach(new TileComponent(
                                    TileTypeEnum.Empty));
                                break;
                        }
                        x = x + emptyTile.Width;
                    }
                    y = y + emptyTile.Height;
                }
            }
        }
    }
}
