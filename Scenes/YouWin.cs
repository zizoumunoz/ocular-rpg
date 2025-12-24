using Raylib_cs;
using System.Numerics;
using System.Text;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Game;

namespace VGP133_Final_Assignment.Scenes
{
    public class YouWin : Scene
    {
        public YouWin(SceneHandler sceneHandler) : base(sceneHandler)
        {
            _background = new Sprite("book_empty", s_origin);
            _youLose = new Text("You lose :(", new Vector2(47, 28), 100, GameColors.DarkBrown);
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);
            _background.Render();
            _youLose.Render();
        }

        public override void Update()
        {

        }

        // Text
        Text _youLose;

        // Sprites
        Sprite _background;
    }
}
