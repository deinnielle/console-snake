using System;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();
            
            while (true)
            {
                if (game.GetInput() || game.UpdateGame())
                    game.Draw();
            }
        }
    }
}