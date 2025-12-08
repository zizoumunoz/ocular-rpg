using System.Numerics;
using Raylib_cs;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Components;
using static VGP133_Final_Assignment.Core.ResolutionManager;    // for UIScale


namespace VGP133_Final_Assignment.Scenes
{
    public class WorldMap : Scene
    {
        public WorldMap(SceneHandler sceneHandler) : base(sceneHandler)
        {
            _borders.Offset = new Vector2(24, 16);
            _buttons.Offset = new Vector2(6, 145);
            _statusWindows.Offset = new Vector2(32, 137);
        }

        public override void Update()
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

        private const int _uiScale = 5;

        // Sprites

        Sprite _background =
            new Sprite("world_background", s_origin, UIScale);
        Sprite _borders =
            new Sprite("world_borders", s_origin, UIScale);
        Sprite _buttons =
            new Sprite("world_buttons", s_origin, UIScale);
        Sprite _statusWindows =
            new Sprite("world_status_window", s_origin, UIScale);

    }
}
