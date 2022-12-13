using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneOS
{
    public class CommandManager
    {
        public List<Command> commands;

        public CommandManager()
        {
            commands = new List<Command>(1);
            commands.Add(new Help("help"));
            commands.Add(new CreateFile("createfile"));
            commands.Add(new DeleteFile("delfile"));
            commands.Add(new ListDir("listdir"));
            commands.Add(new CreateDir("createdir"));
            commands.Add(new DelDir("deldir"));
            commands.Add(new Clear("clear"));
            commands.Add(new Shutdown("shutdown"));
            commands.Add(new Write("write"));
            commands.Add(new Read("read"));
            commands.Add(new MIV("miv"));
            commands.Add(new BF("bf"));
            commands.Add(new ASM("asm"));
        }

        public String processInput(String input)
        {
            String[] args = input.Split(" ");

            foreach (Command cmd in commands)
            {
                if (cmd.name == args[0])
                {
                    return cmd.execute(args);
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            return "Could Not Find The Command \"" + args[0] +"\".";
        }
    }
}
