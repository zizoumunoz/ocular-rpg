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

        public override void Attack(Character player, Text eventLog)
        {
            Random rng = new Random();
            int calculatedDamage = (int)Atk - player.Def;

            if (calculatedDamage <= 0)
            {
                calculatedDamage = 1;
            }

            bool specialSuccess = rng.Next(100) < (int)_specialAtkChance;
            if (specialSuccess)
            {
                eventLog.TextData +=
                    $"\n{Name} reinforces themselves! {Name} defense increases by 10." +
                    $"\n{Name} does {Atk} damage to {player.Name}!";
                Def += 10;
                player.CurrentHp -= calculatedDamage;
            }
            else
            {
                eventLog.TextData +=
                    $"\n{Name} attacks {player.Name} for {calculatedDamage}!";
            }
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
