using Raylib_cs;
using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Core;
using VGP133_Final_Assignment.Core.Viewports;
using VGP133_Final_Assignment.Game.Monsters;

namespace VGP133_Final_Assignment.Game
{
    public class Castle : Terrain
    {
        public Castle(Vector2 location, List<Monster>? monsterPool, Character player)
            : base(location, monsterPool, player)
        {
            _name = "Castle";
            _location = location;
            _sprite = new Sprite("terrain_boss", _location);

            Vector2 offset = new Vector2(5, 2);

            _actionsText[0] =
                new Text("Attack", _actionTopLeft.PositionRaw + offset, 20, Color.White);
            _actionsText[1] =
                new Text("Flee", _actionTopRight.PositionRaw + offset, 20, Color.White);
            _actionsText[2] =
                new Text("Item", _actionBottomLeft.PositionRaw + offset, 20, Color.White);
            _actionsText[3] =
                new Text("Special", _actionBottomRight.PositionRaw + offset, 20, Color.White);

            _viewport =
                new Viewport(new Vector2(49, 40), new Vector2(110, 110), "Inventory", player);

            _castleMonsters = new Monster[3];
            _castleMonsters[0] = new Medusa(Variant.Boss);
            _castleMonsters[1] = new Golem(Variant.Boss);
            _castleMonsters[2] = new Boss(Variant.Boss);
        }

        public override void Render()
        {
            _sprite.Render();
        }

        public override void RenderActionText()
        {
            for (int i = 0; i < _actionsText.Length; i++)
            {
                _actionsText[i].Render();
            }
        }

        public override void Update()
        {
            _actionBottomLeft.Update();
            _actionBottomRight.Update();
            _actionTopLeft.Update();
            _actionTopRight.Update();
        }

        static Monster[] _castleMonsters;

        public static Monster[] CastleMonsters { get => _castleMonsters; set => _castleMonsters = value; }
    }
}
