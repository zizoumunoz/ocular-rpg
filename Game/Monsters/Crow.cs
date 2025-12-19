using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game.Monsters
{
    public class Crow : Monster
    {
        public Crow(Variant variant) : base(variant)
        {
            _name = "Crow";
            _atk = 20;
            _def = 10;
            _hp = 90;
            _goldDropped = 50;
            _xpDropped = 25;
            _specialAtkChance = 50f;
            _spriteOffset = new Vector2(20, 42);

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
                    $"\n{Name} sharpens their claws! {Name}'s damage increased by 5";
                Atk += 5;
            }
            else
            {
                eventLog.TextData +=
                    $"\n{Name} attacks {player.Name} for {calculatedDamage}!";
                player.CurrentHp -= calculatedDamage;
            }

        }

        private void ApplyVariant()
        {
            switch (_variant)
            {
                case Variant.Forest:
                    _sprite = new Sprite("enemy_crow", _spriteOffset);
                    break;
                case Variant.Mountain:
                    _sprite = new Sprite("enemy_crow_mountain", _spriteOffset);
                    _name = "Mountain Crow";
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
