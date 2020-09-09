using System.Collections.Generic;

namespace Snake
{
    public class GameState
    {
        public Point Size { get; set; }
        public Queue<Point> Snake { get; set; }
        public Point Head { get; set; }
        public Direction Direction { get; set; }
        public Point Apple { get; set; }

        public static GameState New => new GameState
        {
            Size = new Point(10, 10),
            Snake = new Queue<Point>(new[]
            {
                new Point(2, 5),
                new Point(3, 5),
                new Point(4, 5),
                new Point(5, 5),
            }),
            Head = new Point(5, 5), // хм
            Apple = new Point(2, 2),
            Direction = Direction.Right
        };
    }
}