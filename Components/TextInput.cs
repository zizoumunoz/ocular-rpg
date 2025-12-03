using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace VGP133_Final_Assignment.Components
{
    public class TextInput
    {
        public TextInput(int length, int height, int xCoord, int yCoord)
        {
            _width = length;
            _height = height;
            _xCoord = xCoord;
            _yCoord = yCoord;
            _box = new Rectangle(_xCoord, _yCoord, _width, _height);
        }

        public void Update()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), _box))
            {
                _isMouseOnText = true;
            }
            else
            {
                _isMouseOnText = false;
            }

            if (_isMouseOnText)
            {
                Raylib.SetMouseCursor(MouseCursor.IBeam);
            }
            else
            {
                Raylib.SetMouseCursor(MouseCursor.Arrow);
            }
        }

        public void Render()
        {

            Raylib.DrawRectangleRec(_box, Color.Red);
        }

        private int _width;
        private int _height;
        private int _xCoord;
        private int _yCoord;
        private string? _textData;
        private bool _isMouseOnText;
        private Rectangle _box;

        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
        public int XCoord { get => _xCoord; set => _xCoord = value; }
        public int YCoord { get => _yCoord; set => _yCoord = value; }
        public string? TextData { get => _textData; set => _textData = value; }
    }
}
