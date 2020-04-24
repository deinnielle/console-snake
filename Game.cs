using System;
using System.Linq;

namespace snake
{
    public class Game
    {
        public ConsoleKeyInfo? _lastKey;
        public DateTime nextUpdate = DateTime.MinValue;
        public Random _random = new Random();
        Snake snake = new Snake();

        public Position StartPosition()
        {
            return new Position()
            {
                left = 0,
                top = 1
            };
        }

        public void Move(ConsoleKeyInfo key)
        {
            Position currentPos;
            if (snake.points.Count != 0)
                currentPos = new Position() {left = snake.points.Last().left, top = snake.points.Last().top};
            else
                currentPos = StartPosition();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    currentPos.left--;
                    break;
                case ConsoleKey.RightArrow:
                    currentPos.left++;
                    break;
                case ConsoleKey.UpArrow:
                    currentPos.top--;
                    break;
                case ConsoleKey.DownArrow:
                    currentPos.top++;
                    break;
            }

            snake.Collision(currentPos);

            snake.points.Add(currentPos);
            snake.RemoveTail();
        }
        
        public void Draw()
        {
            Console.Clear();
            foreach (var point in snake.points)
            {
                Console.SetCursorPosition(point.left, point.top);
                Console.Write('*');
            }

            if (snake._foodPosition != null)
            {
                Console.SetCursorPosition(snake._foodPosition.left, snake._foodPosition.top);
                Console.Write('X');
            }

            Console.SetCursorPosition(0, 0);
            Console.Write($"Score: {snake._score}");
        }

        public bool UpdateGame()
        {
            if (DateTime.Now < nextUpdate) return false;

            if (snake._foodPosition == null)
            {
                snake._foodPosition = new Position()
                {
                    left = _random.Next(Console.WindowWidth),
                    top = _random.Next(1, Console.WindowHeight)
                };
            }

            if (_lastKey.HasValue)
            {
                Move(_lastKey.Value);
            }

            nextUpdate = DateTime.Now.AddMilliseconds(200 / (snake._score + 1));
            return true;
        }

        public bool GetInput()
        {
            if (!Console.KeyAvailable)
                return false;

            _lastKey = Console.ReadKey();

            return true;
        }
        
        public void GameOver()
        {
            throw new Exception();
        }
        
    }
}