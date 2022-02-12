using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Concurrent
{
    abstract class AbsDataMT06
    {
        public abstract char[] TryRead();
        public abstract void TryWrite(char c);

    }//class
}
