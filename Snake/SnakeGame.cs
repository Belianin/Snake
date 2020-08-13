using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeGame
    {
        private readonly IVisualisator visualisator;
        private readonly IController controller;
        private readonly GameState state;
        private readonly TimeSpan tick = TimeSpan.FromSeconds(1);

        public SnakeGame(IVisualisator visualisator, IController controller)
        {
            this.visualisator = visualisator;
            this.controller = controller;
        }

        public void Play(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                var command = controller.GetUserCommand();
                DoGameTick(command);
                
                var view = GetView();
                visualisator.Visualise(view);
                
                Task.Delay(tick, token).Wait(token);
            }
        }

        private GameView GetView()
        {
            throw new NotImplementedException();
        }

        private void DoGameTick(Command command)
        {
            
        }
    }
}