using System.Numerics;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game.Monsters
{
    public class Boss : Monster
    {
        public Boss(Variant variant) : base(variant)
        {
            _name = "Boss";
            _atk = 25;
            _def = 25;
            _hp = 100;
            _goldDropped = 500;
            _xpDropped = 250;
            _specialAtkChance = 10f;
            _spriteOffset = new Vector2(15, 18);

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
                    $"\n{Name} applies fear into {player.Name}'s heart! " +
                    $"\n{player.Name}'s stats decreased by 1";
                player.Atk -= 1;
                player.Def -= 1;
                player.CurrentHp -= 1;
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
                    _sprite = new Sprite("enemy_boss", _spriteOffset);
                    break;
                case Variant.Mountain:
                    _sprite = new Sprite("enemy_boss", _spriteOffset);
                    _name = "Mountain Crow";
                    _atk *= 2;
                    _def *= 2;
                    _hp *= 1.5f;
                    _goldDropped *= 2;
                    _xpDropped *= 1.5f;
                    break;
                case Variant.Boss:
                    _sprite = new Sprite("enemy_boss", _spriteOffset);
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
