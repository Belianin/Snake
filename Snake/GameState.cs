using System.Collections.Generic;

namespace Snake
{
    public class GameState
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public Queue<Point> Snake { get; set; }
        public int Apple { get; set; }
    }
}