using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OzoneOS
{
    public class CreateDir : Command
    {
        public CreateDir(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Sys.FileSystem.VFS.VFSManager.CreateDirectory(args[1]);
            return "Sucessfully Created File " + args[1];
        }
    }
}