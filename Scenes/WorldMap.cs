using System.Numerics;
using VGP133_Final_Assignment.Core;
using Raylib_cs;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Scenes
{
    public class WorldMap : Scene
    {
        public WorldMap(SceneHandler sceneHandler) : base(sceneHandler)
        {
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);

            _background.Render();
            _borders.Render();
            _buttons.Render();
            _statusWindows.Render();

            Raylib.DrawText("WorldMap Scene", 0, 0, 20, Color.RayWhite);
        }

        public override void Update()
        {

        }

        private const int _uiScale = 5;

        // Sprites

        Sprite _background =
            new Sprite("world_background", new Vector2(0, 0), _uiScale);
        Sprite _borders =
            new Sprite("world_borders", new Vector2(0, 0), _uiScale);
        Sprite _buttons =
            new Sprite("world_buttons", new Vector2(0, 0), _uiScale);
        Sprite _statusWindows =
            new Sprite("world_status_window", new Vector2(0, 0), _uiScale);

    }
}
