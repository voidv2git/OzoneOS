using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using System.IO;

namespace OzoneOS
{
    public class BF : Command
    {
        public BF(String name) : base(name) { }

        public override string execute(string[] args)
        {
            FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

            if (fs.CanRead)
            {
                Byte[] data = new Byte[256];
                fs.Read(data, 0, data.Length);
                String text = Encoding.ASCII.GetString(data);
                Compile(text);
            }
            else
            {
                return "Unsucessfully Able To Read File " + args[1];
            }

            return "\nExited With 0 Errors";
        }

        void Compile(String code)
        {
            char[] tape;
            tape = new char[30000];
            int pointer = 0;
            var unmatchedBracketCounter = 0;

            for (int i = 0; i < code.Length; i++)
            {
                switch (code[i])
                {
                    case '<':
                        pointer--;
                        break;
                    case '>':
                        pointer++;
                        break;
                    case '+':
                        tape[pointer]++;
                        break;
                    case '-':
                        tape[pointer]--;
                        break;
                    case '.':
                        Console.Write(tape[pointer]);
                        break;
                    case ',':
                        var key = Console.ReadKey();
                        tape[pointer] = key.KeyChar;
                        break;
                    case '[':
                        if (tape[pointer] == 0)
                        {
                            unmatchedBracketCounter++;
                            while (code[i] != ']' || unmatchedBracketCounter != 0)
                            {
                                i++;
                                if (code[i] == '[')
                                {
                                    unmatchedBracketCounter++;
                                }
                                else if (code[i] == ']')
                                {
                                    unmatchedBracketCounter--;
                                }
                            }
                        }
                        break;
                    case ']':
                        if (tape[pointer] != 0)
                        {
                            unmatchedBracketCounter++;
                            while (code[i] != '[' || unmatchedBracketCounter != 0)
                            {
                                i--;

                                if (code[i] == ']')
                                {
                                    unmatchedBracketCounter++;
                                }
                                else if (code[i] == '[')
                                {
                                    unmatchedBracketCounter--;
                                }
                            }
                        }
                        break;
                }
            }
        }
    }
}