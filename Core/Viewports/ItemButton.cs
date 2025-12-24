using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using VGP133_Final_Assignment.Interfaces;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using Raylib_cs;
using static VGP133_Final_Assignment.Game.GameColors;

namespace VGP133_Final_Assignment.Core.Viewports
{
    public class ItemButton : IDrawable
    {
        public ItemButton(Item item, Vector2 position, int fontSize, Color color)
        {
            _item = item;
            _position = position;
            _fontSize = fontSize;
            _color = color;

            // label and an invisible hit area matching the label row
            _label = new Text($"{_item.Name} x{_item.Quantity}", _position, _fontSize, _color);
            _hitArea = new ButtonRectangle(new Vector2(100, _fontSize), _position, "", false);
        }

        // IDrawable
        public void Update()
        {
            // keep label text in sync with item quantity
            _label.TextData = $"{_item.Name} x{_item.Quantity}";

            _hitArea.Update();
            if (_hitArea.IsPressed)
            {
                _wasPressed = true;
                // clear the underlying pressed flag so callers rely on WasPressed consumption
                _hitArea.IsPressed = false;
            }

            _label.Update();
        }

        // IDrawable
        public void Render()
        {
            _label.Render();
        }

        // Consumable-on-read pressed flag so callers can check once and react
        public bool WasPressed
        {
            get
            {
                var v = _wasPressed;
                _wasPressed = false;
                return v;
            }
        }

        public Item Item => _item;

        private Item _item;
        private Vector2 _position;
        private int _fontSize;
        private Color _color;
        private Text _label;
        private ButtonRectangle _hitArea;
        private bool _wasPressed = false;
    }
}