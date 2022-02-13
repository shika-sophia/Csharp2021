using CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.Performance
{
    class BothLockMT06 : AbsReadWriteLock
    {
        private volatile int doing = 0;

        public override void ReadLock()
        {
            WriteLock();
        }

        public override void ReadUnlock()
        {
            WriteUnlock();
        }

        public override void WriteLock()
        {
        ReCondition:
            while (doing > 0)
            {
                Thread.SpinWait(Timeout.Infinite);
            }

            lock (this)
            {
                if (doing > 0) { goto ReCondition; }

                doing++;
            }//lock
        }//WriteLock()

        public override void WriteUnlock()
        {
            doing--;
            Thread.Yield();
        }//WriteUnlock()
    }//class
}
