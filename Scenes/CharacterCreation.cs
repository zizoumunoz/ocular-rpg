using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;

namespace VGP133_Final_Assignment.Scenes
{
    public class CharacterCreation : Scene
    {
        public CharacterCreation(SceneHandler sceneHandler) : base(sceneHandler)
        {
            SceneName = "Character Creation";
        }
        public override void Update()
        {
            _nameBox.Update();
        }
        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawText("Character Creation Scene", 0, 0, 20, Color.DarkGray);
            _nameBox.Render();
        }

        private TextInput _nameBox = new TextInput(700, 50, 200, 250);

    }
}
