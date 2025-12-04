using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Text;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Character
    {
        public Character(HairColor hairColor, Gender gender, Age age, Class playerClass)
        {
            _hairColor = hairColor;
            _gender = gender;
            _age = age;
            _playerClass = playerClass;

            switch (_hairColor)
            {
                case HairColor.Pink:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            _playerHair = new Sprite("Assets/character_creation/hair_pink_boy.png", new Vector2(0, 0), 5);
                            break;
                        case Gender.Other:
                            _playerHair = new Sprite("Assets/character_creation/hair_pink_other.png", new Vector2(0, 0), 5);
                            break;
                        case Gender.Fem:
                            _playerHair = new Sprite("Assets/character_creation/hair_pink_girl.png", new Vector2(0, 0), 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                case HairColor.Yellow:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            _playerHair = new Sprite("Assets/character_creation/hair_yellow_boy.png", new Vector2(0, 0), 5);
                            break;
                        case Gender.Other:
                            _playerHair = new Sprite("Assets/character_creation/hair_yellow_other.png", new Vector2(0, 0), 5);
                            break;
                        case Gender.Fem:
                            _playerHair = new Sprite("Assets/character_creation/hair_yellow_girl.png", new Vector2(0, 0), 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                case HairColor.Blue:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            _playerHair = new Sprite("Assets/character_creation/hair_blue_boy.png", new Vector2(0, 0), 5);
                            break;
                        case Gender.Other:
                            _playerHair = new Sprite("Assets/character_creation/hair_blue_other.png", new Vector2(0, 0), 5);
                            break;
                        case Gender.Fem:
                            _playerHair = new Sprite("Assets/character_creation/hair_blue_girl.png", new Vector2(0, 0), 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {

        }

        public void Render()
        {
            _playerHair.Render();
        }

        private Sprite _playerBody;
        private Sprite _playerHair;
        private Sprite _playerHat;
        private Sprite _playerFace;

        private HairColor _hairColor;
        private Gender _gender;
        private Age _age;
        private Class _playerClass;


        public HairColor HairColor { get => _hairColor; set => _hairColor = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public Age Age { get => _age; set => _age = value; }
        public Class PlayerClass { get => _playerClass; set => _playerClass = value; }
    }
}
