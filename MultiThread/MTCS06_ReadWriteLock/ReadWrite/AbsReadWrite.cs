using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite
{
    abstract class AbsReadWrite
    {
        public abstract void ReadLock();
        public abstract void ReadUnlock();
        public abstract void WriteLock();
        public abstract void WriteUnlock();
    }//class
}
