using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Raylib_cs;

namespace VGP133_Final_Assignment.Components
{
    public class ButtonRectangle
    {
        public ButtonRectangle(int length, int height, int x, int y, bool render = false)
        {
            _width = length;
            _height = height;
            _x = x;
            _y = y;
            _hitbox = new Rectangle(x, y, length, height);
            _texture =
                new Sprite("Assets/character_creation/selected_left_heart.png", new Vector2(x, y), 5);

            if (render)
            {
                _color = new Color(255, 0, 0, 50);
            }
            else
            {
                _color = new Color(0, 0, 0, 0);
            }
        }

        public void Update()
        {
            // check hover
            _isMouseHovering = Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), _hitbox);

            // toggle is clicked
            if (_isMouseHovering && Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Console.WriteLine("Clicked Button");
                _isPressed = true;
            }
        }

        public void Render()
        {
            Raylib.DrawRectangle(_x, _y, _width, _height, _color);
            _texture.Render();
        }

        private bool _isMouseHovering;
        private bool _isPressed;
        private Rectangle _hitbox;
        private Sprite _texture;
        private Color _color;


        private int _width;
        private int _height;
        private int _x;
        private int _y;



        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
    }
}
