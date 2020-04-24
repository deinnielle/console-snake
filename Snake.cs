using System;
using System.Collections.Generic;
using System.Linq;

namespace snake
{
    public class Snake
    {
        public List<Position> points = new List<Position>();
        public int _length = 3;
        public int _score = 0;
        public Position _foodPosition;
        private Game game;

        public void Collision(Position currentPos)
        {
            if (currentPos.top < 1 || currentPos.top > Console.WindowHeight
                                   || currentPos.left < 0 || currentPos.left > Console.WindowWidth)
            {
                game.GameOver();
            }

            if (points.Any(p => p.left == currentPos.left && p.top == currentPos.top))
            {
                game.GameOver();
            }

            if (_foodPosition.left == currentPos.left && _foodPosition.top == currentPos.top)
            {
                _length++;
                _score++;
                _foodPosition = null;
            }
        }
        
        public void RemoveTail()
        {
            while (points.Count() > _length)
            {
                points.Remove(points.First());
            }
        }
    }
}