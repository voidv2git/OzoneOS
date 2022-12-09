using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace OzoneOS
{
    public class DeleteFile : Command
    {
        public DeleteFile(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Sys.FileSystem.VFS.VFSManager.DeleteFile(args[1]);
            return "Sucessfully Deleted File " + args[1];
        }
    }
}