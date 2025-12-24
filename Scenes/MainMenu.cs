using VGP133_Final_Assignment.Core;
using Raylib_cs;
using VGP133_Final_Assignment.Components;
using System.Numerics;

namespace VGP133_Final_Assignment.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu(SceneHandler sceneHandler) : base(sceneHandler)
        {
            _newGame =
                new ButtonRectangle(73, 17, 67, 64, "main_menu_options", false);
            _loadGame =
                new ButtonRectangle(73, 17, 67, 84, "", false);
            _settings =
                new ButtonRectangle(73, 17, 67, 104, "", false);
            _exit =
                new ButtonRectangle(73, 17, 67, 124, "", false);

            _background = new Sprite("book_empty", s_origin);
            _menuOptions = new Sprite("main_menu_options", s_origin + new Vector2(67,64));
            _logo = new Sprite("logo", s_origin + new Vector2(47, 28));

            
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.White);
            _background.Render();
            _menuOptions.Render();
            _newGame.Render();
            _loadGame.Render();
            _settings.Render();
            _exit.Render();
            _logo.Render();
        }

        public override void Update()
        {
            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            switch (key)
            {
                case KeyboardKey.One:
                    Handler.CurrentScene = new CharacterCreation(Handler);
                    break;
                case KeyboardKey.Two:
                    Handler.CurrentScene = new WorldMap(Handler);
                    break;
                default:
                    break;
            }

            _newGame.Update();
            _loadGame.Update();
            _settings.Update();
            _exit.Update();

            if (_newGame.IsPressed)
            {
                Console.WriteLine("Pressed new game");
                Handler.CurrentScene = new CharacterCreation(Handler);
                _newGame.IsPressed = false;
            }
            else if (_loadGame.IsPressed)
            {
                Console.WriteLine("Pressed load game");
                
                _loadGame.IsPressed = false;
            }
            else if (_settings.IsPressed)
            {
                Console.WriteLine("Pressed settings");
                _settings.IsPressed = false;
            }
            else if (_exit.IsPressed)
            {
                Console.WriteLine("Pressed exit");
                _exit.IsPressed = false;
            }

        }

        private ButtonRectangle _newGame;
        private ButtonRectangle _loadGame;
        private ButtonRectangle _settings;
        private ButtonRectangle _exit;

        private Sprite _background;
        private Sprite _menuOptions;
        private Sprite _logo;
    }
}
