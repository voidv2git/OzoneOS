using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneOS
{
    public class Shutdown : Command
    {
        public Shutdown(String name) : base(name) { }

        public override string execute(string[] args)
        {
            Cosmos.System.Power.Shutdown();
            return "Shutting Down Now...";
        }
    }
}