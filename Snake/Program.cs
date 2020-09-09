using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\u001b[35mThis is purple\u001b[0m");
            SnakeGame.New.Play(CancellationToken.None);
        }
    }
}
