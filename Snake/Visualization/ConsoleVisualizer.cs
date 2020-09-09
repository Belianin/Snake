using System;

namespace Snake.Visualization
{
    public class ConsoleVisualizer : IVisualizer
    {
        public void Visualise(GameView view)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int y = 0; y < view.Size.Y; y++) 
                Console.WriteLine(new string('.', view.Size.X));

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var snake in view.Snake)
            {
                Console.SetCursorPosition(snake.X, snake.Y);
                Console.Write("#");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(view.Apple.X, view.Apple.Y);
            Console.Write("*");
        }
    }
}