using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.DeadLock
{
    public class ToolDeadLock
    {
        private readonly string name;

        public ToolDeadLock(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return $"[{name}]";
        }
    }//class
}
