using System.Collections.Generic;

namespace Snake
{
    public class GameView
    {
        public IEnumerable<Point> Snake { get; set; }
        public Point Apple { get; set; }
        public Point Size { get; set; }
    }
}