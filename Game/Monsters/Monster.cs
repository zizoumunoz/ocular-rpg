using System.Numerics;
using VGP133_Final_Assignment.Components;
using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Game.Monsters
{
    public abstract class Monster : IDrawable
    {
        public Monster(Variant variant)
        {
            _variant = variant;
        }

        public abstract void Render();

        public abstract void Update();

        public Monster ShallowCopy()
        {
            return (Monster)this.MemberwiseClone();
        }

        public void Attack()
        {

        }

        public void BasicAttack()
        {

        }

        public void SpecialAttack()
        {

        }

        // Monster Attributes
        protected string _name = "";
        protected float _atk;
        protected float _def;
        protected float _hp;
        protected float _goldDropped;
        protected float _xpDropped;
        protected float _specialAtkChance;
        protected Variant _variant;
        protected Sprite _sprite;

        // Sprite attributes
        protected Vector2 _spriteOffset;

        public string Name { get => _name; set => _name = value; }
        public float Atk { get => _atk; set => _atk = value; }
        public float Def { get => _def; set => _def = value; }
        public float Hp { get => _hp; set => _hp = value; }
        public float GoldDropped { get => _goldDropped; set => _goldDropped = value; }
        public float XpDropped { get => _xpDropped; set => _xpDropped = value; }
    }
}
