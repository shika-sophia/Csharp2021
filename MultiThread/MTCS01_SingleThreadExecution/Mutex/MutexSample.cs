using System;
using System.Threading;

namespace CsharpBegin.MultiThread.MTCS01_SingleThreadExecution.Mutex
{
    internal class MutexSample : AbsMutex
    {
        private volatile bool lockFlag = false; //some Thread has lock.
        private volatile int thCount = 0;       //count of waiting Thread
        private readonly int thMax;
        private readonly Random random = new Random();

        public MutexSample(int thMax)
        {
            this.thMax = thMax;
        }

        internal override void Lock()
        {
            lock (this)
            {
                thCount++;
                while (lockFlag)
                {
                    //random wait for 50-150 millisecond.
                    Thread.SpinWait(random.Next(100) + 50);

                    if (thCount >= thMax)
                    {
                        break;
                    }
                }//while

                thCount--;
                lockFlag = true;
            }//lock() as synchronized
        }//MutexSmaple.Lock()

        internal override void Unlock()
        {
            lockFlag = false;
            Thread.Yield();
        }//Unlock()
    }//class
}