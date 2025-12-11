using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Castle : Terrain
    {
        public Castle(Vector2 location, List<Monster>? monsterPool) : base(location, monsterPool)
        {
            _name = "Castle";
            _location = location;
            _sprite = new Sprite("terrain_boss", _location);
        }

        public override void Render()
        {
            _sprite.Render();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
