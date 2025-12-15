using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Game
{
    public abstract class Terrain : IDrawable
    {
        protected Terrain(Vector2 location, List<Monster>? monsterPool)
        {
            _location = location;
            _monsterPool = monsterPool;

            _actionTopLeft =
               new ButtonRectangle(62, 20, 234, 160, "", false);
            _actionTopRight =
               new ButtonRectangle(62, 20, 299, 160, "", false);
            _actionBottomLeft =
               new ButtonRectangle(62, 20, 234, 183, "", false);
            _actionBottomRight =
               new ButtonRectangle(62, 20, 299, 183, "", false);
        }

        public abstract void Render();

        public abstract void Update();

        public abstract void RenderActionText();

        protected string _name = "";
        protected Vector2 _location;
        protected Sprite? _sprite;
        protected List<Monster> _monsterPool;
        protected float _rewardChance;

        public string Name { get => _name; set => _name = value; }
        public Vector2 Location { get => _location; set => _location = value; }

        public ButtonRectangle ActionTopLeft { get => _actionTopLeft; set => _actionTopLeft = value; }
        public ButtonRectangle ActionTopRight { get => _actionTopRight; set => _actionTopRight = value; }
        public ButtonRectangle ActionBottomLeft { get => _actionBottomLeft; set => _actionBottomLeft = value; }
        public ButtonRectangle ActionBottomRight { get => _actionBottomRight; set => _actionBottomRight = value; }

        // 4 Action Buttons
        protected ButtonRectangle _actionTopLeft;
        protected ButtonRectangle _actionTopRight;
        protected ButtonRectangle _actionBottomLeft;
        protected ButtonRectangle _actionBottomRight;

        protected Text[] _actionsText = new Text[4];
    }
}
