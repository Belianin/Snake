using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            SnakeGame.New.Play(CancellationToken.None);
        }
    }
}
