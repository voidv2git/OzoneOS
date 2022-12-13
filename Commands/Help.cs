using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneOS
{
    public class Help : Command
    {
        public Help(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Graphics graphics = new Graphics();
            CommandManager commandManager = new CommandManager();

            graphics.setColor(ConsoleColor.Gray, ConsoleColor.Black);

            graphics.drawTaskbar();

            graphics.changeColor(ConsoleColor.Blue, ConsoleColor.White);
            Console.SetCursorPosition(56, 0);
            Console.WriteLine("OzoneOS Help Application");

            graphics.changeColor(ConsoleColor.Gray, ConsoleColor.Black);

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Here Are All Of The Current Commands In OzoneOS:");

            foreach (Command command in commandManager.commands)
            {
                Console.WriteLine(command.name);
            }

            Console.WriteLine("Press Any Key To Quit...");

            Console.ReadKey();

            graphics.setColor(ConsoleColor.Black, ConsoleColor.White);

            return "";
        }
    }
}