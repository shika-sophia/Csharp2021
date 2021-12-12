using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution
{
    abstract class AbsMT01Gate
    {
        abstract public void PassGate(string name, string address);
        abstract internal void CheckGate();
    }//class
}
