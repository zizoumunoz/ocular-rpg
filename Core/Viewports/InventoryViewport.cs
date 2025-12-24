using System.Numerics;
using System.Collections.Generic;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Game;
using static VGP133_Final_Assignment.Core.ResolutionManager;
using static VGP133_Final_Assignment.Game.GameColors;
using Raylib_cs;

namespace VGP133_Final_Assignment.Core.Viewports
{
    public class InventoryViewport : Viewport
    {
        private const int MaxRows = 12;
        private List<ButtonRectangle> _itemButtons = new List<ButtonRectangle>();
        private List<Text> _itemTexts = new List<Text>();

        public InventoryViewport(Vector2 position, Vector2 dimensions, Character player, bool isActive = false)
            : base(position, dimensions, "Inventory", player, isActive)
        {
            // keep close button and body consistent with base behaviour
            _closeButton =
                new ButtonRectangle(new Vector2(8, 8), position, "button_close", true);
            _body =
                new Rectangle(_position * UIScale, _dimensions * UIScale);
            _isActive = isActive;

            // content offset inside the viewport (logical coords)
            _contentOffset = _position + new Vector2(6, 10);

            RebuildList();
        }

        // Build UI rows from the inventory source (either _contents if set, otherwise player's inventory)
        private void RebuildList()
        {
            _itemButtons.Clear();
            _itemTexts.Clear();

            var source = _contents ?? _player.Inventory;
            if (source == null) return;

            Vector2 rowOffset = new Vector2(0, 0);
            int i = 0;
            foreach (var item in source.Items)
            {
                if (i >= MaxRows) break;

                // create an invisible button that matches the text row area (logical coords)
                var btn = new ButtonRectangle(new Vector2(100, 14), _contentOffset + rowOffset, "", false);
                _itemButtons.Add(btn);

                // label sits slightly inset from the button origin
                var label = new Text($"{item.Name} x{item.Quantity}", _contentOffset + rowOffset + new Vector2(4, 1), 14, DarkBrown);
                _itemTexts.Add(label);

                rowOffset += new Vector2(0, 16);
                i++;
            }
        }

        public override void Update()
        {
            base.Update();
            if (!_isActive) return;

            // update UI rows
            for (int i = 0; i < _itemButtons.Count; i++)
            {
                _itemButtons[i].Update();
                // if pressed, handle usage and rebuild list to reflect changes
                if (_itemButtons[i].IsPressed)
                {
                    TryUseItemAtIndex(i);
                    _itemButtons[i].IsPressed = false;
                    RebuildList();
                    break;
                }
            }
        }

        public override void Render()
        {
            base.Render();
            if (!_isActive) return;

            // render labels only (buttons are invisible by default)
            for (int i = 0; i < _itemTexts.Count; i++)
            {
                _itemTexts[i].Render();
            }
        }

        private void TryUseItemAtIndex(int index)
        {
            var source = _contents ?? _player.Inventory;
            if (source == null) return;
            if (index < 0 || index >= source.Items.Count) return;

            var item = source.Items[index];
            if (item == null || item.Quantity <= 0) return;

            switch (item.Type)
            {
                case "Consumable":
                    if (item.Name.ToLower().Contains("health"))
                    {
                        _player.CurrentHp = System.Math.Min(_player.MaxHp, _player.CurrentHp + 50);
                    }
                    else if (item.Name.ToLower().Contains("attack"))
                    {
                        _player.Atk += 2;
                    }
                    else if (item.Name.ToLower().Contains("defense"))
                    {
                        _player.Def += 2;
                    }

                    item.Quantity = System.Math.Max(0, item.Quantity - 1);
                    if (item.Quantity == 0)
                    {
                        source.Items.RemoveAt(index);
                    }
                    break;

                case "Equipable":
                    // simple equip behaviour (example)
                    if (item.Name.ToLower().Contains("sword")) _player.Atk += 5;
                    if (item.Name.ToLower().Contains("shield")) _player.Def += 3;
                    // consume one for now
                    item.Quantity = System.Math.Max(0, item.Quantity - 1);
                    if (item.Quantity == 0)
                    {
                        source.Items.RemoveAt(index);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
