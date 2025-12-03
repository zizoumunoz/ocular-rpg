using System;
using System.Collections.Generic;
using System.Text;
using VGP133_Final_Assignment.Core;
using Raylib_cs;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Scenes
{
    public class MainMenu : Scene
    {
        public MainMenu(SceneHandler sceneHandler) : base(sceneHandler)
        {

        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.White);
            _background.Render();
            Raylib.DrawText("Main Menu Scene", 200, 200, 20, Color.Black);
        }
        public override void Update()
        {
            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();
            switch (key)
            {
                case KeyboardKey.One:
                    Handler.CurrentScene = new CharacterCreation(Handler);
                    break;

                default:
                    break;
            }
        }

        private Sprite _background =
            new Sprite("Assets/book_sketch.png", new System.Numerics.Vector2(0f, 0f), 5f);

        public Sprite Background { get => _background; set => _background = value; }
    }
}
