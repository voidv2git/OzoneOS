using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using System.IO;

namespace OzoneOS
{
    public class ASM : Command
    {
        public ASM(String name) : base(name) { }

        public override string execute(string[] args)
        {
            FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

            if (fs.CanRead)
            {
                Byte[] data = new Byte[256];
                fs.Read(data, 0, data.Length);
                String[] code = Encoding.ASCII.GetString(data).Split("\n");
                return Compile(code);
            }
            else
            {
                return "Unsucessfully Able To Read File " + args[1];
            }
        }

        String Compile(String[] code)
        {
            String retValue;

            Core.RAM _ram = new Core.RAM();
            String[] ram = _ram.ram;
            for (int i = 0; i < code.Length; i++)
            {
                String instruction = code[i].Split(" ")[0];
                String[] _args = code[i].Replace(instruction + " ", "").Split(",");

                try
                {
                    switch (instruction)
                    {
                        case "STOR":
                            ram[Int32.Parse(_args[0])] = _args[1];
                            break;
                        case "LOAD":
                            ram[Int32.Parse(_args[0])] = ram[Int32.Parse(_args[0])];
                            break;
                        case "PRNT":
                            Console.Write(ram[Int32.Parse(_args[0])]);
                            break;
                        case "INP":
                            String input = Console.ReadLine();
                            ram[Int32.Parse(_args[0])] = input;
                            break;
                        case "PRNTL":
                            Console.WriteLine(ram[Int32.Parse(_args[0])]);
                            break;
                        case "ADD":
                            ram[Int32.Parse(_args[0])] = (Int32.Parse(ram[Int32.Parse(_args[0])]) + Int32.Parse(ram[Int32.Parse(_args[1])])).ToString();
                            break;
                        case "SUB":
                            ram[Int32.Parse(_args[0])] = (Int32.Parse(ram[Int32.Parse(_args[0])]) - Int32.Parse(ram[Int32.Parse(_args[1])])).ToString();
                            break;
                        case "IF":
                            if (_args[1] == "=")
                            {
                                if (ram[Int32.Parse(_args[0])] != _args[2])
                                {
                                    while (instruction != "END")
                                    {
                                        i++;
                                        instruction = code[i].Split(" ")[0];
                                    }
                                }
                            }
                            else if (_args[1] == "!")
                            {
                                if (ram[Int32.Parse(_args[0])] == _args[2])
                                {
                                    while (instruction != "END")
                                    {
                                        i++;
                                        instruction = code[i].Split(" ")[0];
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                retValue = "Instruction Error On Line " + i + ".\n" + code[i];
                                return retValue;
                            }
                            break;
                        case "MUL":
                            ram[Int32.Parse(_args[0])] = (Int32.Parse(ram[Int32.Parse(_args[0])]) * Int32.Parse(ram[Int32.Parse(_args[1])])).ToString();
                            break;
                        case "DIV":
                            ram[Int32.Parse(_args[0])] = (Int32.Parse(ram[Int32.Parse(_args[0])]) / Int32.Parse(ram[Int32.Parse(_args[1])])).ToString();
                            break;
                        case "BCOL":
                            switch (_args[0])
                            {
                                case "Black":
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    break;
                                case "White":
                                    Console.BackgroundColor = ConsoleColor.White;
                                    break;
                                case "Red":
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    break;
                                case "Green":
                                    Console.BackgroundColor = ConsoleColor.Green;
                                    break;
                                case "Blue":
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    break;
                                case "Grey":
                                    Console.BackgroundColor = ConsoleColor.Gray;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    retValue = "COLOR Error On Line " + i + ".\n" + code[i];
                                    return retValue;
                            }
                            break;
                        case "FCOL":
                            switch (_args[0])
                            {
                                case "Black":
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    break;
                                case "White":
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                case "Red":
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case "Green":
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    break;
                                case "Blue":
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                                case "Grey":
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    break;
                                default:
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    retValue = "COLOR Error On Line " + i + ".\n" + code[i];
                                    return retValue;
                            }
                            break;
                        case "CLR":
                            Console.Clear();
                            break;
                        case "INC":
                            ram[Int32.Parse(_args[0])] = (Int32.Parse(ram[Int32.Parse(_args[0])]) + 1).ToString();
                            break;
                        case "DEC":
                            ram[Int32.Parse(_args[0])] = (Int32.Parse(ram[Int32.Parse(_args[0])]) - 1).ToString();
                            break;
                        case "END":
                            break;
                        case "STOP":
                            return "The program '' has exited with code 0 (0x0).";
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            retValue = "INSTRUCTION Error On Line " + i + ".\n" + code[i];
                            return retValue;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    retValue = "SYNTAX Error On Line " + i + ".\n" + code[i];
                    return retValue;
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            retValue = "STOP Error. This Happens When You Do Not Include A STOP Instruction At The End Of Your Code.";
            return retValue;
        }
    }
}