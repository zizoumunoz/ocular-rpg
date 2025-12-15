using Raylib_cs;
using System.Numerics;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;

namespace VGP133_Final_Assignment.Core
{
    public class Viewport : IDrawable
    {
        public Viewport(Vector2 position, Vector2 dimensions, bool isVisisble = false)
        {
            _position = position;
            _dimensions = dimensions;
            _isVisible = isVisisble;
        }
        public void Update()
        {
        }

        public void Render()
        {
            Raylib.DrawRectangleV(_position, _dimensions, Color.Red);
        }


        private Vector2 _position;
        private Vector2 _dimensions;
        private bool _isVisible;
    }
}
