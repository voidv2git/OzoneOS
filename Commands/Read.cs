using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using System.IO;

namespace OzoneOS
{
    public class Read : Command
    {
        public Read(String name) : base(name) { }

        public override string execute(string[] args)
        {
            FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

            if (fs.CanRead)
            {
                Byte[] data = new Byte[256];
                fs.Read(data, 0, data.Length);
                return Encoding.ASCII.GetString(data);
            }
            else
            {
                return "Unsucessfully Able To Read File " + args[1];
            }
        }
    }
}