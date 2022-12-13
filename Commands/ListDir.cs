using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OzoneOS
{
    public class ListDir : Command
    {
        public ListDir(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Graphics graphics = new Graphics();
            CommandManager commandManager = new CommandManager();

            graphics.setColor(ConsoleColor.Gray, ConsoleColor.Black);
            graphics.drawTaskbar();

            graphics.changeColor(ConsoleColor.Blue, ConsoleColor.White);
            Console.SetCursorPosition(59, 0);
            Console.WriteLine("OzoneOS File Explorer");

            graphics.changeColor(ConsoleColor.Gray, ConsoleColor.Black);

            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Current Files In Directory \"" + args[1] + "\":");

            var dirList = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(args[1]);
            foreach (var dir in dirList)
            {
                Console.WriteLine(dir.mName);
            }

            Console.WriteLine("Press Any Key To Quit...");
            Console.ReadKey();

            graphics.setColor(ConsoleColor.Black, ConsoleColor.White);

            return "";
        }
    }
}