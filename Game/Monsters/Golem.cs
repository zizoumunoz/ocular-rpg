using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game.Monsters
{
    public class Golem : Monster
    {
        public Golem(Variant variant) : base(variant)
        {
            _name = "Golem";
            _atk = 10;
            _def = 50;
            _hp = 100;
            _goldDropped = 100;
            _xpDropped = 50;
            _specialAtkChance = 10f;
            _spriteOffset = new Vector2(44, 38);

            ApplyVariant();
        }

        public override void Render()
        {
            _sprite.Render();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        private void ApplyVariant()
        {
            switch (_variant)
            {
                case Variant.Forest:
                    _sprite = new Sprite("enemy_golem", _spriteOffset);
                    break;
                case Variant.Mountain:
                    _sprite = new Sprite("enemy_golem_mountain", _spriteOffset);
                    _name = "Mountain Golem";
                    _atk *= 2;
                    _def *= 2;
                    _hp *= 1.5f;
                    _goldDropped *= 2;
                    _xpDropped *= 1.5f;
                    break;
                case Variant.Boss:
                    _atk *= 2.5f;
                    _def *= 2.5f;
                    _hp *= 1.5f;
                    _goldDropped *= 2;
                    _xpDropped *= 1.5f;
                    break;
                default:
                    Console.WriteLine("Could not apply variant for golem");
                    break;
            }
        }
    }
}
