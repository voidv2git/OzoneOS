using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OzoneOS
{
    public class CreateFile : Command
    {
        public CreateFile(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Sys.FileSystem.VFS.VFSManager.CreateFile(args[1]);
            return "Sucessfully Created File " + args[1];
        }
    }
}