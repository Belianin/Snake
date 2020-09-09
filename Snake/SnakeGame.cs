using System;
using System.Threading;
using System.Threading.Tasks;
using Snake.Control;
using Snake.Visualization;

namespace Snake
{
    public class SnakeGame
    {
        private readonly IVisualizer visualizer;
        private readonly IController controller;
        private readonly GameState state;
        private readonly TimeSpan tick = TimeSpan.FromMilliseconds(500);

        public SnakeGame(IVisualizer visualizer, IController controller, GameState state)
        {
            this.visualizer = visualizer;
            this.controller = controller;
            this.state = state;
        }
        
        public static SnakeGame New => new SnakeGame(
            new BufferedConsoleVisualizer(), 
            new ConsoleController(),
            GameState.New);

        public void Play(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var command = controller.GetUserCommand();
                DoGameTick(command);
                
                var view = GetView();
                visualizer.Visualise(view);
                
                Task.Delay(tick, token).Wait(token);
            }
        }

        private GameView GetView()
        {
            return new GameView
            {
                Snake = state.Snake.ToArray(),
                Apple = state.Apple,
                Size = state.Size
            };
        }

        private void DoGameTick(Command command)
        {
            state.Snake.Dequeue();

            var head = Move(command);

            state.Head = head;
            state.Snake.Enqueue(head);
        }

        private Point Move(Command command)
        {
            var newDirection = Turn(command);
            state.Direction = newDirection;
            switch (newDirection)
            {
                case Direction.Up:
                    return new Point(state.Head.X % state.Size.X, (state.Head.Y - 1 + 10) % state.Size.Y);
                case Direction.Right:
                    return new Point((state.Head.X + 1) % state.Size.X, state.Head.Y % state.Size.Y);
                case Direction.Down:
                    return new Point(state.Head.X % state.Size.X, (state.Head.Y + 1) % state.Size.Y);
            }
            return new Point((state.Head.X - 1 + 10) % state.Size.X, state.Head.Y % state.Size.Y);
        }

        private Direction Turn(Command command)
        {
            if (command == Command.Forward)
                return state.Direction;
            
            switch (state.Direction)
            {
                case Direction.Right:
                    return command == Command.Right ? Direction.Down : Direction.Up;
                case Direction.Down:
                    return command == Command.Right ? Direction.Left : Direction.Right;
                case Direction.Left:
                    return command == Command.Right ? Direction.Up : Direction.Down;
            }

            return command == Command.Right ? Direction.Right : Direction.Left;
        }
    }
}