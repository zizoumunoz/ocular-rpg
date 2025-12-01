using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Raylib_cs;


namespace VGP133_Final_Assignment.Core
{
    public class Game
    {


        public void Run()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                Raylib.DrawText("Hello, world!", 12, 12, 20, Color.Black);

                Raylib.EndDrawing();
            }
        }
    }
}
