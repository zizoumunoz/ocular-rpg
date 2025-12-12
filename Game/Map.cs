using System.Numerics;
using VGP133_Final_Assignment.Interfaces;

namespace VGP133_Final_Assignment.Game
{
    public class Map : IDrawable
    {
        public Map()
        {
            for (int column = 0; column < _mapTiles.GetLength(1); column++)
            {
                _mapTiles[0, column] =
                    new Ocean(new Vector2(205 + 30 * column, 21), _monsters);
                _mapTiles[4, column] =
                    new Ocean(new Vector2(205 + 30 * column, 141), _monsters);
            }

            _mapTiles[1, 0] =
                new Forest(new Vector2(205, 51), _monsters);
            _mapTiles[1, 1] =
                new Forest(new Vector2(235, 51), _monsters);
            _mapTiles[1, 2] =
                new Forest(new Vector2(265, 51), _monsters);
            _mapTiles[1, 3] =
                new Mountain(new Vector2(295, 51), _monsters);
            _mapTiles[1, 4] =
                new Mountain(new Vector2(325, 51), _monsters);

            _mapTiles[2, 0] =
                new Village(new Vector2(205, 81), _monsters);
            _mapTiles[2, 1] =
                new Forest(new Vector2(235, 81), _monsters);
            _mapTiles[2, 2] =
                new Forest(new Vector2(265, 81), _monsters);
            _mapTiles[2, 3] =
                new Mountain(new Vector2(295, 81), _monsters);
            _mapTiles[2, 4] =
                new Castle(new Vector2(325, 81), _monsters);

            _mapTiles[3, 0] =
                new Forest(new Vector2(205, 111), _monsters);
            _mapTiles[3, 1] =
                new Forest(new Vector2(235, 111), _monsters);
            _mapTiles[3, 2] =
                new Mountain(new Vector2(265, 111), _monsters);
            _mapTiles[3, 3] =
                new Mountain(new Vector2(295, 111), _monsters);
            _mapTiles[3, 4] =
                new Mountain(new Vector2(325, 111), _monsters);

            //_mapTiles[4, 0] =
            //    new Forest(new Vector2(205, 81), _monsters);
            //_mapTiles[4, 1] =
            //    new Forest(new Vector2(235, 81), _monsters);
            //_mapTiles[4, 2] =
            //    new Forest(new Vector2(265, 81), _monsters);
            //_mapTiles[4, 3] =
            //    new Mountain(new Vector2(295, 81), _monsters);
            //_mapTiles[4, 4] =
            //    new Mountain(new Vector2(325, 81), _monsters);


        }

        private Vector2 _playerLocation;
        private Terrain[,] _mapTiles = new Terrain[5, 5];
        List<Monster> _monsters = new List<Monster>();

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Render()
        {
            for (int column = 0; column < _mapTiles.GetLength(1); column++)
            {
                _mapTiles[0, column].Render();
                _mapTiles[1, column].Render();
                _mapTiles[2, column].Render();
                _mapTiles[3, column].Render();
                _mapTiles[4, column].Render();
            }
        }
    }
}
