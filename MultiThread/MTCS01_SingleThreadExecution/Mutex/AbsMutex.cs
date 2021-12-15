using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Mutex
{
    abstract class AbsMutex
    {
        internal abstract void Lock();
        internal abstract void Unlock();
    }//class 
}
