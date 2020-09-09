using System;
using System.IO;
using System.Text;

namespace Snake.Visualization
{
    public class BufferedConsoleVisualizer : IVisualizer
    {
        public void Visualise(GameView view)
        {
            var screen = BuildScreen(view);
            Console.Clear();
            Console.Write(screen);
        }

        private string BuildScreen(GameView view)
        {
            var field = new string[view.Size.Y, view.Size.X];
            for (int i = 0; i < view.Size.X; i++)
            {
                for (int j = 0; j < view.Size.Y; j++)
                {
                    field[i, j] = " ";
                }
            }

            foreach (var point in view.Snake)
            {
                field[point.Y, point.X] = "#";
            }

            field[view.Apple.Y, view.Apple.X] = "*";
            
            var sb = new StringBuilder();
            sb.AppendLine("╔" + new string('═', view.Size.X) + "╗");
            for (int i = 0; i < view.Size.X; i++)
            {
                sb.Append("║");
                for (int j = 0; j < view.Size.Y; j++)
                {
                    sb.Append(field[i, j]);
                }

                sb.Append("║");
                sb.AppendLine();
            }

            sb.AppendLine("╚" + new string('═', view.Size.X) + "╝");

            return sb.ToString();
        }
    }
}