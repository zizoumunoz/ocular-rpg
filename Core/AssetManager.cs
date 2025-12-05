using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Text;

namespace VGP133_Final_Assignment.Core
{
    public static class AssetManager
    {
        public static void LoadAssets()
        {
            // character_creation assets
            string assetFolder = "Assets/character_creation";
            string[] files = Directory.GetFiles(assetFolder, "*.png");

            foreach (var file in files)
            {
                string key = Path.GetFileNameWithoutExtension(file);
                _textures[key] = Raylib.LoadTexture(file);
            }
        }

        public static void UnloadAssets()
        {
            Console.WriteLine("Unloading assets...");
            foreach (var texture in _textures.Values)
            {
                Raylib.UnloadTexture(texture);
            }
        }

        public static Texture2D GetTexture(string textureName)
        {
            if (_textures.TryGetValue(textureName, out Texture2D texture))
            {
                return texture;
            }
            else
            {
                Console.WriteLine($"Could not find texture: {textureName}");
                return default;
            }
        }

        private static Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
    }
}
