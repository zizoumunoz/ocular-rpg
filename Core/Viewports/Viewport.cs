using Raylib_cs;
using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using static VGP133_Final_Assignment.Game.GameColors;

namespace VGP133_Final_Assignment.Core.Viewports
{
    public class Viewport : IDrawable
    {
        public Viewport(Vector2 position, Vector2 dimensions, string name, Character player, bool isActive = false)
        {
            _name = name;
            _position = position;
            _dimensions = dimensions;
            _contentOffset = _position + new Vector2(3, 3);
            _player = player;
            _closeButton =
                new ButtonRectangle(new Vector2(8, 8), position, "button_close", true);
            _body =
                new Rectangle(_position * UIScale, _dimensions * UIScale);
            _isActive = isActive;
        }
        public virtual void Update()
        {
            if (!_isActive) { return; }
            _closeButton.Update();
            if (_closeButton.IsPressed)
            {
                _isActive = false;
                _closeButton.IsPressed = false;
            }
        }

        public virtual void Render()
        {
            if (!_isActive) { return; }
            Raylib.DrawRectangleRounded(_body, 0.08f, 1, LightBrown);
            Raylib.DrawRectangleRoundedLinesEx(_body, 0.1f, 5, 8f, DarkBrown);
            Raylib.DrawText(
                _name,
                (int)(_position.X + 3) * UIScale,
                (int)(_position.Y + 2) * UIScale,
                20,
                DarkBrown
                );
            _closeButton.Render();
        }

        protected Inventory _contents;
        protected string _name;
        protected ButtonRectangle _closeButton;
        protected Vector2 _position;
        protected Vector2 _contentOffset;
        protected Vector2 _dimensions;
        protected Rectangle _body;
        protected bool _isActive;
        protected Character _player;
        public bool IsActive { get => _isActive; set => _isActive = value; }
        public Character Player { get => _player; set => _player = value; }
        public Inventory Contents { get => _contents; set => _contents = value; }
    }
}
