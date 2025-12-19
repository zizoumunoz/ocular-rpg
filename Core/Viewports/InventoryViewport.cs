using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using Raylib_cs;

namespace VGP133_Final_Assignment.Core.Viewports
{
    public class InventoryViewport : Viewport
    {
        public InventoryViewport(Vector2 position, Vector2 dimensions, Character player, bool isActive = false)
            : base(position, dimensions, "Inventory", player, isActive)
        {
            _closeButton =
                new ButtonRectangle(new Vector2(8, 8), position, "button_close", true);
            _body =
                new Rectangle(_position * UIScale, _dimensions * UIScale);
            _isActive = isActive;
            _contentOffset = _position + new Vector2(3, 3);

            _items = new Text[6];

            Vector2 verticalOffset = new Vector2(0, 20);
            int iterator = 0;
            foreach (var item in _player.Inventory.Items)
            {
                _items[iterator] = new Text(item.Name, _contentOffset + verticalOffset, 20, GameColors.DarkBrown);
                iterator++;
                verticalOffset += new Vector2(0, 10);
            }

        }

        public override void Update()
        {
            base.Update();
            Vector2 verticalOffset = new Vector2(0, 20);
            int iterator = 0;
            foreach (var item in _player.Inventory.Items)
            {
                _items[iterator] = new Text($"{item.Name}: {item.Quantity}", _contentOffset + verticalOffset, 20, GameColors.DarkBrown);
                iterator++;
                verticalOffset += new Vector2(0, 10);
            }
        }

        public override void Render()
        {
            base.Render();
            if (_isActive)
            {
                foreach (var item in _items)
                {
                    item.Render();
                }
            }
        }

        private Text[] _items;
    }
}
