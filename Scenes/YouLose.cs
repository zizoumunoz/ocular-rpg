using Raylib_cs;
using VGP133_Final_Assignment.Core;

namespace VGP133_Final_Assignment.Scenes
{
    public class YouLose : Scene
    {
        public YouLose(SceneHandler sceneHandler) : base(sceneHandler)
        {
        }

        public override void Render()
        {
            Raylib.ClearBackground(Color.RayWhite);
            Raylib.DrawText("You Lose Scene", 0, 0, 20, Color.Black);
        }

        public override void Update()
        {
        }
    }
}
