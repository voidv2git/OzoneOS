using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using System.IO;

namespace OzoneOS
{
    public class Write : Command
    {
        public Write(String name) : base(name) { }

        public override string execute(string[] args)
        {
            FileStream fs = (FileStream)Sys.FileSystem.VFS.VFSManager.GetFile(args[1]).GetFileStream();

            if (fs.CanWrite)
            {
                Byte[] data = Encoding.ASCII.GetBytes(args[2]);

                fs.Write(data, 0, data.Length);
                fs.Close();
                return "Sucessfully Wrote To File " + args[1];
            }
            else
            {
                return "Unsucessfully Wrote To File " + args[1];
            }
        }
    }
}