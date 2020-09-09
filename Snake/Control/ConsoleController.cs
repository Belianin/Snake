using System;
using System.Threading.Tasks;

namespace Snake.Control
{
    public class ConsoleController : IController
    {
        private Command command = Command.Forward;

        public ConsoleController()
        {
            Task.Run(ListenKeyboard);
        }
        
        public Command GetUserCommand()
        {
            var nextCommand = command;

            command = Command.Forward;
            
            return nextCommand;
        }

        private void ListenKeyboard()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        command = Command.Left;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        command = Command.Right;
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        command = Command.Forward;
                        break;
                }
            }
        }
    }
}