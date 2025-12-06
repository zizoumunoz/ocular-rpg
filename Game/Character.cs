using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using VGP133_Final_Assignment.Components;

namespace VGP133_Final_Assignment.Game
{
    public class Character
    {
        public Character(Vector2 spriteLocation)
        {
            _spriteLocation.X = spriteLocation.X * 5;
            _spriteLocation.Y = spriteLocation.Y * 5;

            _playerClass = Class.Wizard;
            _hairColor = HairColor.Pink;
            _age = Age.Young;
            _gender = Gender.Masc;

            _playerBody = new Sprite("character_body", _spriteLocation, 5);
            _playerHair = new Sprite("hair_pink_boy", _spriteLocation + _hairBoyOffset, 5);
            _playerHat = new Sprite("hat_wizard", _spriteLocation + _hatWizardOffset, 5);
            _playerCloak = new Sprite("clothes_wizard", _spriteLocation + _cloaksOffset, 5);
            _playerFace = new Sprite("face_young", _spriteLocation + _faceYoungOffest, 5);

            _atk = 10;
            _def = 5;
            _currentHp = 150;

        }

        public void Update()
        {

        }

        public void UpdateStats()
        {
            switch (PlayerClass)
            {
                case Class.Knight:
                    _atk = 5;
                    _def = 10;
                    _currentHp = 200;
                    break;
                case Class.Jester:
                    _atk = 5;
                    _def = 5;
                    _currentHp = 100;
                    break;
                case Class.Wizard:
                    _atk = 10;
                    _def = 5;
                    _currentHp = 150;
                    break;
                default:
                    break;
            }
        }

        public void UpdateSprite()
        {
            switch (_hairColor)
            {
                case HairColor.Pink:
                    switch (_gender)
                    {
                        case Gender.Masc:
                            _playerHair = new Sprite("hair_pink_boy", _spriteLocation + _hairBoyOffset, 5);
                            break;
                        case Gender.Other:
                            _playerHair = new Sprite("hair_pink_other", _spriteLocation + _hairOtherOffset, 5);
                            break;
                        case Gender.Fem:
                            _playerHair = new Sprite("hair_pink_girl", _spriteLocation + _hairGirlOffset, 5);
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
                            _playerHair = new Sprite("hair_yellow_boy", _spriteLocation + _hairBoyOffset, 5);
                            break;
                        case Gender.Other:
                            _playerHair = new Sprite("hair_yellow_other", _spriteLocation + _hairOtherOffset, 5);
                            break;
                        case Gender.Fem:
                            _playerHair = new Sprite("hair_yellow_girl", _spriteLocation + _hairGirlOffset, 5);
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
                            _playerHair = new Sprite("hair_blue_boy", _spriteLocation + _hairBoyOffset, 5);
                            break;
                        case Gender.Other:
                            _playerHair = new Sprite("hair_blue_other", _spriteLocation + _hairOtherOffset, 5);
                            break;
                        case Gender.Fem:
                            _playerHair = new Sprite("hair_blue_girl", _spriteLocation + _hairGirlOffset, 5);
                            break;
                        default:
                            Console.WriteLine("Sprite data not found");
                            break;
                    }
                    break;
                default:
                    break;
            }

            switch (_playerClass)
            {
                case Class.Knight:
                    _playerHat = new Sprite("hat_knight", _spriteLocation + _hatKnightOffset, 5);
                    _playerCloak = new Sprite("clothes_knight", _spriteLocation + _cloaksOffset, 5);
                    break;
                case Class.Jester:
                    _playerHat = new Sprite("hat_jester", _spriteLocation + _hatJesterOffset, 5);
                    _playerCloak = new Sprite("clothes_jester", _spriteLocation + _cloaksOffset, 5);
                    break;
                case Class.Wizard:
                    _playerHat = new Sprite("hat_wizard", _spriteLocation + _hatWizardOffset, 5);
                    _playerCloak = new Sprite("clothes_wizard", _spriteLocation + _cloaksOffset, 5);
                    break;
                default:
                    break;
            }

            switch (_age)
            {
                case Age.Young:
                    _playerFace = new Sprite("face_young", _spriteLocation + _faceYoungOffest, 5);
                    break;
                case Age.Adult:
                    _playerFace = new Sprite("face_adult", _spriteLocation + _faceAdultOffest, 5);
                    break;
                case Age.Old:
                    _playerFace = new Sprite("face_old", _spriteLocation + _faceOldOffest, 5);
                    break;
                default:
                    break;
            }
        }

        public void Render()
        {
            _playerCloak.Render();
            _playerBody.Render();
            _playerFace.Render();
            _playerHair.Render();
            _playerHat.Render();


        }

        // ===== Player Stats
        private const int _maxHp = 500;
        private int _currentHp;
        private int _atk;
        private int _def;
        private int _level;
        private int _xp;

        private Vector2 _spriteLocation;

        private Sprite _playerCloak;
        private Sprite _playerBody;
        private Sprite _playerHair;
        private Sprite _playerHat;
        private Sprite _playerFace;

        private const int _uiScale = 5;

        // Accessory sprite offsets relative to body sprite
        private static Vector2 _cloaksOffset = new Vector2(2 * _uiScale, 34 * _uiScale);
        private static Vector2 _hatKnightOffset = new Vector2(-3 * _uiScale, -5 * _uiScale);
        private static Vector2 _hatWizardOffset = new Vector2(-5 * _uiScale, -22 * _uiScale);
        private static Vector2 _hatJesterOffset = new Vector2(-16 * _uiScale, -19 * _uiScale);
        private static Vector2 _hairBoyOffset = new Vector2(0, -12 * _uiScale);
        private static Vector2 _hairOtherOffset = new Vector2(0, -7 * _uiScale);
        private static Vector2 _hairGirlOffset = new Vector2(-3* _uiScale, -8 * _uiScale);
        private static Vector2 _faceYoungOffest = new Vector2(13 * _uiScale, 15 * _uiScale);
        private static Vector2 _faceAdultOffest = new Vector2(16 * _uiScale, 17 * _uiScale);
        private static Vector2 _faceOldOffest = new Vector2(11 * _uiScale, 18 * _uiScale);

        private HairColor _hairColor;
        private Gender _gender;
        private Age _age;
        private Class _playerClass;
        
        public HairColor HairColor { get => _hairColor; set => _hairColor = value; }
        public Gender Gender { get => _gender; set => _gender = value; }
        public Age Age { get => _age; set => _age = value; }
        public Class PlayerClass { get => _playerClass; set => _playerClass = value; }
        public Vector2 SpriteLocation { get => _spriteLocation; set => _spriteLocation = value; }
        public int MaxHp { get => _maxHp; }
        public int CurrentHp { get => _currentHp; set => _currentHp = value; }
        public int Atk { get => _atk; set => _atk = value; }
        public int Def { get => _def; set => _def = value; }
        public int Level { get => _level; set => _level = value; }
        public int Xp { get => _xp; set => _xp = value; }
    }
}
