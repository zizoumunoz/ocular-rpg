using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace VGP133_Final_Assignment.Components
{
    public class ButtonCircle
    {
        public ButtonCircle(float radius, int xCoordinate, int yCoordinate)
        {
            _radius = radius;
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        


        private float _radius;
        private int _xCoordinate;
        private int _yCoordinate;

        public float Radius { get => _radius; set => _radius = value; }
        public int XCoordinate { get => _xCoordinate; set => _xCoordinate = value; }
        public int YCoordinate { get => _yCoordinate; set => _yCoordinate = value; }
    }
}
