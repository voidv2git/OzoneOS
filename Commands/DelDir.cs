using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OzoneOS
{
    public class DelDir : Command
    {
        public DelDir(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Sys.FileSystem.VFS.VFSManager.DeleteDirectory(args[1], true);
            return "Sucessfully Created File " + args[1];
        }
    }
}