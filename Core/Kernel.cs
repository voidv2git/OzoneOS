using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;

namespace OzoneOS
{
    public class Kernel : Sys.Kernel
    {
        private CommandManager commandManager;
        private Graphics graphics;
        private CosmosVFS vfs;

        protected override void BeforeRun()
        {
            vfs = new CosmosVFS();
            graphics = new Graphics();

            Sys.FileSystem.VFS.VFSManager.RegisterVFS(this.vfs);

            commandManager = new CommandManager();
            Console.WriteLine(@"   ____                       ____   _____ 
  / __ \                     / __ \ / ____|
 | |  | |_______  _ __   ___| |  | | (___  
 | |  | |_  / _ \| '_ \ / _ \ |  | |\___ \ 
 | |__| |/ / (_) | | | |  __/ |__| |____) |
  \____//___\___/|_| |_|\___|\____/|_____/ 
OzoneOS successfully booted up.
");
        }
        
        protected override void Run()
        {
            var y = Console.CursorTop;
            var x = Console.CursorLeft;

            graphics.drawTaskbar();

            Console.SetCursorPosition(x, y);

            Console.Write("OzoneOS > ");
            String input = Console.ReadLine();
            String output = commandManager.processInput(input);
            Console.WriteLine(output);
        }
    }
}
