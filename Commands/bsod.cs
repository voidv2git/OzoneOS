using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneOS
{
    public class bsod : Command
    {
        public bsod(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Graphics graphics = new Graphics();
            graphics.setColor(ConsoleColor.Blue, ConsoleColor.White);
            Console.WriteLine(":(\nYour PC Ran Into A Problem And Needs To Restart.");
            while (true) { }
        }
    }
}