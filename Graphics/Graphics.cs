using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneOS
{
    public class Graphics
    {
        public void setColor(ConsoleColor color1, ConsoleColor color2)
        {
            Console.BackgroundColor = color1;
            Console.ForegroundColor = color2;
            Console.Clear();
        }

        public void changeColor(ConsoleColor color1, ConsoleColor color2)
        {
            Console.BackgroundColor = color1;
            Console.ForegroundColor = color2;
        }

        public void drawTaskbar()
        {
            Console.SetCursorPosition(0, 0);
            changeColor(ConsoleColor.Blue, ConsoleColor.White);
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(DateTime.Now.ToString("h:mm tt"));
            changeColor(ConsoleColor.Black, ConsoleColor.White);
        }
    }
}
