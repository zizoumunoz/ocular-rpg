using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game.Monsters
{
    public class Medusa : Monster
    {
        public Medusa(Variant variant) : base(variant)
        {
            _name = "Medusa";
            _atk = 30;
            _def = 10;
            _hp = 50;
            _goldDropped = 100;
            _xpDropped = 50;
            _specialAtkChance = 20f;
            _spriteOffset = new Vector2(45, 37);

            ApplyVariant();
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
                    $"\n{Name} temporarily petrifies {player.Name}! {Name} attacks twice!" +
                    $"\n{Name} does {calculatedDamage} damage to {player.Name}" +
                    $"\n{Name} does {calculatedDamage} damage to {player.Name}";
                player.CurrentHp -= calculatedDamage;
                player.CurrentHp -= calculatedDamage;
            }
            else
            {
                eventLog.TextData +=
                    $"\n{Name} attacks {player.Name} for {calculatedDamage}!";
                player.CurrentHp -= calculatedDamage;
            }
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
                    _sprite = new Sprite("enemy_lamia", _spriteOffset);
                    break;
                case Variant.Mountain:
                    _sprite = new Sprite("enemy_lamia_mountain", _spriteOffset);
                    _name = "Mountain Medusa";
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
