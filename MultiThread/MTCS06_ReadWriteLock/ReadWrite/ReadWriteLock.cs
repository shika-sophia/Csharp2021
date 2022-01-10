using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpBegin.MultiThread.MTCS06_ReadWriteLock.ReadWrite
{
    class ReadWriteLock : AbsReadWrite
    {
        private int reading = 0;
        private int waitWrite = 0;
        private int writing = 0;
        private bool preferWrite = true; //Write優先なら true

        public override void ReadLock()
        {
            lock (this)
            {
                while(writing > 0 
                    || (preferWrite && waitWrite > 0))
                {
                    Thread.SpinWait(Timeout.Infinite);
                }//while

                reading++;
            }//lock
        }//ReadLock()

        public override void ReadUnlock()
        {
            lock (this)
            {
                reading--;
                preferWrite = true;
                Thread.Yield();
            }//lock
        }//ReadUnlock()

        public override void WriteLock()
        {
            lock (this)
            {
                waitWrite++;

                try
                {
                    while(reading > 0 || writing > 0)
                    {
                        Thread.SpinWait(Timeout.Infinite);
                    }//while
                }
                finally
                {
                    waitWrite--;
                }

                writing++;
            }//lock
        }//WriteLock()

        public override void WriteUnlock()
        {
            lock (this)
            {
                writing--;
                preferWrite = false;
                Thread.Yield();
            }//lock
        }//WriteUnlock()
    }//class
}
