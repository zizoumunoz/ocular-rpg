using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using Raylib_cs;
using System.Collections.Generic;
using static VGP133_Final_Assignment.Game.GameColors;

namespace VGP133_Final_Assignment.Core.Viewports
{
    public class ShopViewport : Viewport
    {
        public ShopViewport(Vector2 position, Vector2 dimensions, string name, Character player, Inventory shopInventory, bool isActive = false)
            : base(position, dimensions, name, player, isActive)
        {
            _shopInventory = shopInventory;
            _closeButton =
                new ButtonRectangle(new Vector2(8, 8), position, "button_close", true);
            _body =
                new Rectangle(_position * UIScale, _dimensions * UIScale);
            _isActive = isActive;
            _contentOffset = _position + new Vector2(6, 10);

            RebuildButtons();
        }

        private void RebuildButtons()
        {
            _buttons = new List<ItemButton>();
            Vector2 row = new Vector2(0, 0);
            int i = 0;
            if (_shopInventory == null) return;
            foreach (var item in _shopInventory.Items)
            {
                if (i >= 12) break;
                var btn = new ItemButton(item, _contentOffset + row, 14, DarkBrown);
                _buttons.Add(btn);
                row += new Vector2(0, 14 + 6);
                i++;
            }
        }

        public override void Update()
        {
            base.Update();
            if (!_isActive) return;

            foreach (var b in _buttons)
            {
                b.Update();
                if (b.WasPressed)
                {
                    TryBuy(b.Item);
                    RebuildButtons();
                    break;
                }
            }
        }

        public override void Render()
        {
            base.Render();
            if (!_isActive) return;

            foreach (var b in _buttons)
            {
                b.Render();
            }
        }

        private void TryBuy(Item shopItem)
        {
            if (shopItem == null) return;
            if (_player.Gold < shopItem.Price) return;

            // spend gold
            _player.Gold -= shopItem.Price;

            // add to player's inventory (increase existing or add new)
            var existing = _player.Inventory.Items.Find(i => i.Name == shopItem.Name);
            if (existing != null)
            {
                existing.Quantity += 1;
            }
            else
            {
                _player.Inventory.Items.Add(new Item(shopItem.Name, shopItem.Type, 1, shopItem.Price));
            }
        }

        private Inventory _shopInventory;
        private List<ItemButton> _buttons = new List<ItemButton>();
    }
}